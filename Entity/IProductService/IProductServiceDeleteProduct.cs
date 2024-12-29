namespace Entity.IProductService
{
	public class IProductServiceDeleteProduct
	{
        public bool Result { get; set; }

		public IProductServiceDeleteProduct(bool result)
		{
			Result = result;
		}

    }


}
