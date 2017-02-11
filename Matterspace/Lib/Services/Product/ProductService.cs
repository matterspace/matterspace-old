using Matterspace.Lib.Services.Thread;
using Matterspace.Model;
using Matterspace.Model.Entities;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Matterspace.Lib.Services.Product
{
    public class ProductService
    {
        public ThreadService ThreadService { get; }

        public ProductService(MatterspaceDbContext db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            this.Db = db;
            this.ThreadService = new ThreadService(this.Db);
        }

        public MatterspaceDbContext Db { get; }

        /// <summary>
        /// Returns the base ViewModel for the given tab
        /// </summary>
        /// <param name="name"></param>
        /// <param name="activeTab"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> GetProductViewModel(string name, ProductActiveTab activeTab)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var product = await this.Db.Products
                .Include(x => x.Members)
                .Include(x => x.Members.Select(m => m.Member))
                .FirstAsync(m => m.Name == name);

            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                DisplayName = product.DisplayName,
                ShortDescription = product.ShortDescription,
                WebsiteUrl = product.WebsiteUrl,
                FacebookUrl = product.FacebookUrl,
                TwitterUrl = product.TwitterUrl,
                ActiveTab = activeTab,
                ThreadsCount = await this.ThreadService.GetThreadsCount(product.Id)
            };
        }

        public async Task SaveProduct(ProductViewModel viewModel)
        {
            Model.Entities.Product product;

            if (viewModel.Id.HasValue)
                product = await this.Db.Products.FindAsync(viewModel.Id.Value);
            else
            {
                product = new Model.Entities.Product();
                this.Db.Products.Add(product);
            }

            product.Name = viewModel.Name.ToLower();
            product.DisplayName = viewModel.DisplayName;
            product.ShortDescription = viewModel.ShortDescription;
            product.WebsiteUrl = viewModel.WebsiteUrl;
            product.TwitterUrl = viewModel.TwitterUrl;
            product.FacebookUrl = viewModel.FacebookUrl;

            await this.Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUserViewModel>> GetMembersInProduct(int productId)
        {
            var members = await this.Db.ProductMembers
                .Include(x => x.Member)
                .Where(x => x.ProductId == productId)
                .Select(x => x.Member)
                .ToListAsync();

            return members.Select(x => new ApplicationUserViewModel()
            {
                UserId = x.Id,
                UserName = x.UserName
            });
        }

        public async Task<OperationResult> AddMemberToProduct(string username, int productId, string userId = null)
        {
            var saveResult = new OperationResult();

            // Get the user by its username
            // If the id is not null (found user with auto complete), use it
            var memberId = !string.IsNullOrEmpty(userId) ? userId
                : await this.Db.Users
                .Where(x => x.UserName == username)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            // If the user exists
            if (!string.IsNullOrEmpty(memberId))
            {
                // Create a new product member
                var productMember = new ProductMember()
                {
                    MembershipType = Model.Enums.ProductMembershipType.Member,
                    ProductId = productId,
                    MemberId = memberId
                };

                var isAlreadyAssigned = await this.Db.ProductMembers
                    .Where(x => x.MemberId == productMember.MemberId && x.ProductId == productMember.ProductId)
                    .AnyAsync();

                // Only if this user isn't assigned to the project
                if (!isAlreadyAssigned)
                {
                    this.Db.ProductMembers.Add(productMember);
                    await this.Db.SaveChangesAsync();
                }
                else
                {
                    saveResult.AddMessage("add-member", "The given user is already assigned to this project", OperationResultMessageType.Error);
                }
            }
            else
            {
                saveResult.AddMessage("add-member", "Could not find the given user", OperationResultMessageType.Error);
            }

            return saveResult;
        }

        public async Task<OperationResult> RemoveMemberFromProduct(string userId, string productName)
        {
            var removeResult = new OperationResult();

            var member = await this.Db.ProductMembers
                .FirstOrDefaultAsync(x => x.Member.Id == userId && x.Product.Name == productName);

            if(member != null)
            {
                this.Db.ProductMembers.Remove(member);
                await this.Db.SaveChangesAsync();
            }
            else
            {
                removeResult.AddMessage("remove-member", "The given user is not a contributor to this project, therefore cannot be removed", OperationResultMessageType.Error);
            }

            return removeResult;
        }
    }
}
