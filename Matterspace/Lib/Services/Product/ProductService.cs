using Matterspace.Lib.Services.Thread;
using Matterspace.Model;
using Matterspace.Model.Entities;
using Matterspace.Model.Enums;
using Matterspace.Models;
using System;
using System.Collections;
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


        // For instance, this method is here because we have two products viewmodels
        public async Task CreateProduct(CreateProductViewModel viewModel)
        {
            var productViewModel = new ProductViewModel
            {
                Name = viewModel.Name,
                DisplayName = viewModel.DisplayName,
                ShortDescription = viewModel.ShortDescription,
                WebsiteUrl = viewModel.WebsiteUrl,
                FacebookUrl = viewModel.FacebookUrl,
                TwitterUrl = viewModel.TwitterUrl
            };

            await this.SaveProduct(productViewModel);
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

            if (!viewModel.Id.HasValue)
            {
                product.Categories = this.GetDefaultCategories(product.Id);
                await this.Db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ThreadCategoryViewModel>> GetCategoriesForProduct(int productId, ThreadType categoryThreadType)
        {
            var categories = await this.Db.Products
                .Where(x => x.Id == productId)
                .SelectMany(x => x.Categories)
                .Where(x => x.ThreadType == categoryThreadType)
                .ToListAsync();

            return this.GetCategoriesListAsViewModel(categories);
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

            if (member != null)
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


        /// <summary>
        /// Gets the default categories for a new product
        /// </summary>
        private ICollection<ThreadCategory> GetDefaultCategories(int productId)
        {
            var categories = new List<ThreadCategory>();

            // Ideas categories
            categories.Add(new ThreadCategory
            {
                Name = "Idea Category 1",
                ProductId = productId,
                ThreadType = ThreadType.Idea
            });

            categories.Add(new ThreadCategory
            {
                Name = "Idea Category 2",
                ProductId = productId,
                ThreadType = ThreadType.Idea
            });

            categories.Add(new ThreadCategory
            {
                Name = "Idea Category 2",
                ProductId = productId,
                ThreadType = ThreadType.Idea
            });

            // Issues categories
            categories.Add(new ThreadCategory
            {
                Name = "Issue Category 1",
                ProductId = productId,
                ThreadType = ThreadType.Issue
            });

            categories.Add(new ThreadCategory
            {
                Name = "Issue Category 2",
                ProductId = productId,
                ThreadType = ThreadType.Issue
            });

            categories.Add(new ThreadCategory
            {
                Name = "Issue Category 3",
                ProductId = productId,
                ThreadType = ThreadType.Issue
            });

            // QA categories
            categories.Add(new ThreadCategory
            {
                Name = "QA Category 1",
                ProductId = productId,
                ThreadType = ThreadType.QA
            });

            categories.Add(new ThreadCategory
            {
                Name = "QA Category 2",
                ProductId = productId,
                ThreadType = ThreadType.QA
            });

            categories.Add(new ThreadCategory
            {
                Name = "QA Category 3",
                ProductId = productId,
                ThreadType = ThreadType.QA
            });

            return categories;
        }

        private IEnumerable<ThreadCategoryViewModel> GetCategoriesListAsViewModel(IEnumerable<ThreadCategory> entityList)
        {
            return entityList
                .Select(x => new ThreadCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductId = x.ProductId
                });
        }
    }
}
