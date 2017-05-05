namespace PCMarket.Models.Entities.Softwares
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;

    public class Software : Component
    {
        public Software() : base(ComponentType.Software)
        {
        }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}