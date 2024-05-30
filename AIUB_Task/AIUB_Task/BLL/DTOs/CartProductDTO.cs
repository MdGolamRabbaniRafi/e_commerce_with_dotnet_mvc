namespace AIUB_Task.BLL.DTOs
{
    public class CartProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string SelectedColor { get; set; }
        public string SelectedSize { get; set; }
    }
}
