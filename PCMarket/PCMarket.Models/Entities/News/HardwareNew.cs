namespace PCMarket.Models.Entities.News
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;
    using Users;

    public class HardwareNew : BaseNew
    {
        public HardwareNew() : base(NewType.Hardware)
        {
        }

        public string NewCategory => this.Category.ToString();

        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual AdminUser Author { get; set; }
    }
}