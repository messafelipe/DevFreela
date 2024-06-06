using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, double totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjectStatusEnum.Created;
            CreatedAt = DateTime.Now;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public double TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinisheAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; set; }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Finished)
                Status = ProjectStatusEnum.Cancelled;
        }


        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Finished;
                FinisheAt = DateTime.Now;
            }
        }

        /// <summary>
        /// Vai ser retirado posteriormente, por causa do Entity Framework
        /// </summary>
        public void Update(string title, string description, double totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}