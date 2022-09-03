namespace Chat_FrontEnd.APIControllers
{
    public interface IApiService<Model> where Model : class
    {
        Model Get(int id);
        List<Model> GetAll();
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
    }
}
