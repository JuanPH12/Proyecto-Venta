namespace Proyecto_Venta.modelos.db
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }
    }
}