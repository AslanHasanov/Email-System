using EmailSystem.DataBase;
using EmailSystem.DataBase.Models;
using EmailSystem.Services.EmailService;
using EmailSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;

namespace EmailSystem.Controllers
{
    public class EmailController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEmailSender _emailconfig;
        private readonly EmailConfiguration _emailsend;
        public EmailController(DataContext dataContext, IEmailSender emailconfig, EmailConfiguration emailsend)
        {
            _dataContext = dataContext;
            _emailconfig = emailconfig;
            _emailsend = emailsend;
        }


        #region List

        [HttpGet("/")]
        public IActionResult List()
        {
            var model = _dataContext.Notifications
              .Select(e => new ListViewModel(e.FromEmail, $"{e.TargetEmail.Email}", e.Title, e.Content))
              .ToList();
            return View("~/Views/List.cshtml", model);
        }

        #endregion


        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            return View("~/Views/Add.cshtml");
        }


        [HttpPost]
        public IActionResult Add([FromForm] AddViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("~/Views/Add.cshtml", model);
            //}

            var notification = new Notification()
            {
                FromEmail = _emailsend.From,
                Title = model.Tittle,
                Content = model.Message,
                TargetEmail = model.TargetEmail

            };

            _dataContext.Notifications.Add(notification);

            _dataContext.TargetEmail.Add(notification.TargetEmail);

            var emails = model.TargetEmail.Email.Trim().Split(',');

            List<string> toEmail = new List<string>();

            if (model.Status == true)
            {
                foreach (var mail in emails)
                {
                    toEmail.Add(mail);
                }

            }
            else if (model.Status == false)
            {
                toEmail.Add(notification.TargetEmail.Email);
            }

            var message = new Message(toEmail, model.Tittle, model.Message);

            _emailconfig.SendEmail(message);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(List));

        }



        #endregion
    }
}
