using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu projeto ASPNET Core 1", "Minha descrição de Projeto 1", 1, 1, 1000)
            };

            Users = new List<User>
            {
                new User("Luis Felipe", "luisdev@luisdev.com.br", new DateTime(1992, 1, 1))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core")
            };
        }

        public List<Project> Projects { get; set; }

        public List<User> Users { get; set; }

        public List<Skill> Skills { get; set; }

        public List <ProjectComment> ProjectComments { get; set; }
    }
}
