namespace Entity.IOrderRepository
{
	public class IOrderRepositoryUpdateOneOrderAsyncRequest
	{

		//business nesnelerinde buradaki tüm özellikler olmasın
		public int RowId { get; set; }

		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }

	}

}