namespace LiquerStore.DAL.Models
{
    public class OrderModel
    {
        public CustomerModel Customer { get; set; }
        public WhiskyModel Whisky { get; set; }
        public bool Completed { get; set; }
    }
}