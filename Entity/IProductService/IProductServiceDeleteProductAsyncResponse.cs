namespace Entity.IProductService
{
	public class IProductServiceDeleteProductAsyncResponse
	{
        public bool Result { get; set; }

		public IProductServiceDeleteProductAsyncResponse(bool result)
		{
			Result = result;
		}

    }


}
