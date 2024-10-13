using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPIService.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
