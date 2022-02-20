using Task = Ass_8.Models.Task;
namespace Ass_8.Services;

public class TaskService : ITaskService
{
    private static readonly List<Task> _datasource = new List<Task>();

    public List<Task> GetAll()
    {
        return _datasource;
    }

    public Task? GetOne(Guid id)
    {
        return _datasource.FirstOrDefault(o => o.Id == id);
    }
    public Task Add(Task task)
    {
        _datasource.Add(task);
        return task;
    }

    public Task? Edit(Task task)
    {
        var current = _datasource.FirstOrDefault(o => o.Id == task.Id);
        if (current == null) return null;

        current.Title = task.Title;
        current.Description = task.Description;
        current.Completed = task.Completed;

        return current;
    }

    public void Remove(Guid id)
    {
        var current = _datasource.FirstOrDefault(o => o.Id == id);
        if (current != null)
        {
            _datasource.Remove(current);
        }
    }

    public List<Task> Add(List<Task> tasks)
    {
        _datasource.AddRange(tasks);
        return tasks;
    }

    public void Remove(List<Guid> ids)
    {
        _datasource.RemoveAll(o => ids.Contains(o.Id));
    }

    public bool Exists(Guid id)
    {
        return _datasource.Any(o => o.Id == id);
    }
}