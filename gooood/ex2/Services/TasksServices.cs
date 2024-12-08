using ex2.Models;
using ex2.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
namespace ex2.Services
{
    public class TasksServices:ITasksServices
    {
        private readonly ITasksRepository _TasksRepository;
        public TasksServices(ITasksRepository TasksRepository)
        {
            _TasksRepository = TasksRepository;
        }

        public bool Add(Tasks task)
        {
            return _TasksRepository.add(task);
        }

        public void Delete(int id)
        {
            var Tasks = Get();
            Tasks Task = Tasks.FirstOrDefault(i => i.Id == id);
             _TasksRepository.delete(Task);
        }

        public IEnumerable<Tasks> Get()
        {
            return _TasksRepository.Get();
        }
        public IEnumerable<Tasks> GetTaskByUser(int Id)
        {
            return _TasksRepository.GetTaskByUser(Id);
        }

        public void Update(Tasks task)
        {
            //var Tasks = Get();
            //Tasks TaskUpdate = Tasks.FirstOrDefault(i => i.Id == task.Id);
            //TaskUpdate.Name = task.Name;
            //TaskUpdate.Priority = task.Priority;
            //TaskUpdate.ProjectId = task.ProjectId;
            //TaskUpdate.Status = task.Status;
            //TaskUpdate.UserId = task.UserId;
            //TaskUpdate.DueDate = task.DueDate;
            //TaskUpdate.AttachmentsId = task.AttachmentsId;
            _TasksRepository.update(task);
        }

        //public void ProcessTransaction(Tasks task, Attachment Attachment)
        //{
        //    _AdoRepository.ProcessTransaction(task, Attachment);
        //}

        //public DataTable addAttachment(Attachment attachment)
        //{
        //    return _TasksRepository.addAttachment(attachment);
        //}
        //public DataTable getByProject(int ProjactId)
        //{
        //    return _TasksRepository.getByProject(ProjactId);
        //}
    }
}
