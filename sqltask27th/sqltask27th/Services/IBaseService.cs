

namespace ADO.NET.Services;
public interface IBaseService<Blog>
{
    List<Blog> GetAll();
    Blog GetById(int id);
    int Create(Blog data);
    int Update(int id, Blog data);
    int Delete(int id);
}