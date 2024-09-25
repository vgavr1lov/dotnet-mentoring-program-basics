using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BrainstormSessions.Controllers
{
   public class SessionController : Controller
   {
      private readonly IBrainstormSessionRepository _sessionRepository;
      private readonly ILogger _logger;

      public SessionController(IBrainstormSessionRepository sessionRepository, ILogger logger)
      {
         _sessionRepository = sessionRepository;
         _logger = logger;
      }

      public async Task<IActionResult> Index(int? id)
      {
         if (!id.HasValue)
         {
            _logger.Debug("Session id is null. Redirecting to Home.");
            return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
         }

         var session = await _sessionRepository.GetByIdAsync(id.Value);
         if (session == null)
         {
            _logger.Debug("Session with {id} was not found.", id.Value);
            return Content("Session not found.");
         }

         _logger.Debug("Session with {id} was found.", id.Value);

         var viewModel = new StormSessionViewModel()
         {
            DateCreated = session.DateCreated,
            Name = session.Name,
            Id = session.Id
         };

         _logger.Debug("The view model is created: Name {name}, Id {Id}", session.Name, session.Id);

         return View(viewModel);
      }
   }
}
