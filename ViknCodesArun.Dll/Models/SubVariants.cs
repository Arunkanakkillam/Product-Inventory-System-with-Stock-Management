namespace ViknCodesArun.Dll.Models
{
    public class SubVariants:Auditable
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public List<string> Option { get; set; }
        public decimal Stock { get; set; }
        public virtual Variants Variant { get; set; }

    }
}
