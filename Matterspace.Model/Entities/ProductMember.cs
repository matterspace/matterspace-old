using Matterspace.Model.Enums;

namespace Matterspace.Model.Entities
{
    public class ProductMember
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public ApplicationUser Member { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public ProductMembershipType MembershipType { get; set; }
    }
}
