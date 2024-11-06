using ChatInteractionService.Model;
using Ollama;

namespace ChatInteractionService.Service;

public interface IActivityService
{
    Task<string> BriefBehavior(int studentId);
    Task<string> BriefParticipation(int studentId);
}
