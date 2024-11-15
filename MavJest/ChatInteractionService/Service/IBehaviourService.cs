﻿
using MavJest.ChatInteractionService.Model;

namespace MavJest.ChatInteractionService.Service;

public interface IBehaviourService
{
    Task<string> StudentTitle(int studentId);
    Task<string> BriefBehavior(int studentId);
    Task<StudentBehaviourProfileViewModel> StudentBehaviourDetail(int studentId);
}