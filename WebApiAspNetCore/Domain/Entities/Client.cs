using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApiAspNetCore.Domain.Entities.Base;

namespace WebApiAspNetCore.Domain.Entities
{
    public class Client : BaseModel
    {
        public Client(string name, string lastname)
        {
            Name = name;
            Lastname = lastname;
            Fullname = name + lastname;
        }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome do cliente
        /// </summary>
        public string Lastname { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string? Fullname { get; set; }
    }
}
