namespace Entity.IProductService
{
	public class IProductServiceDeleteProductResponse
	{
        public bool Result { get; set; }

		public IProductServiceDeleteProductResponse(bool result)
		{
			Result = result;
		}

    }


}
