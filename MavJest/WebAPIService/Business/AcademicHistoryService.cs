using MavJest.Database.Repository;
using MavJest.WebAPIService.Models;

namespace MavJest.WebAPIService.Business;

public class AcademicHistoryService : IAcademicHistoryService
{
    private IAcademicHistoryRepository academicHistoryRepository;

    public AcademicHistoryService(IAcademicHistoryRepository academicHistoryRepository)
    {
        this.academicHistoryRepository = academicHistoryRepository;
    }

    public AcademicDetailModel GetAcademicDetail(int id)
    {
        var records = this.academicHistoryRepository.GetStudentAcademicHistory(id);
        var totalMath = records.Sum(x => x.Maths.GetValueOrDefault());
        var countMath = records.Count(x => x.Maths != null);
        var totalHindi = records.Sum(x => x.Hindi.GetValueOrDefault());
        var countHindi = records.Count(x => x.Hindi != null);
        var totalEnglish = records.Sum(x => x.English.GetValueOrDefault());
        var countEnglish = records.Count(x => x.English != null);
        return new AcademicDetailModel
        {
            OverallScore = (totalEnglish + totalHindi + totalMath) / (countEnglish + countHindi + countMath),
            MathScore = totalMath / countMath,
            HindiScore = totalHindi / countHindi,
            EnglishScore = totalEnglish / countEnglish
        };
    }
}
