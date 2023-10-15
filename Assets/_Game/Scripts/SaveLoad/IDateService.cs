public interface IDataService
{
    public void SaveData<T>(string relativePath, T data);

    public T LoadData<T>(string relativePath);
}