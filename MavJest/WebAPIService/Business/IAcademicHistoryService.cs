using MavJest.WebAPIService.Models;

namespace MavJest.WebAPIService.Business;

public interface IAcademicHistoryService
{
    AcademicDetailModel GetAcademicDetail(int id);
}