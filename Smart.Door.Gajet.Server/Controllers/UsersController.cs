using Azx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Smart.Door.Gajet.Server.Controllers
{
    public class UsersController : Infrastructure.BaseApiControllerWithDatabase
    {
        public UsersController(Data.IUnitOfWork unitOfWork,Services.IUserService userService)
            : base(unitOfWork: unitOfWork)
        {
            UserService = userService;
        }

        protected Services.IUserService UserService { get; }


        //// *******************************
        ////         Login
        //// *******************************
        //[Microsoft.AspNetCore.Mvc.HttpPost(template:"login")]

        //[Microsoft.AspNetCore.Cors.EnableCors(policyName: Startup.OTHERS_CORS_POLICY)]

        //[Microsoft.AspNetCore.Mvc.ProducesResponseType
        //    (typeof(ViewModels.User.LoginResponseViewModel), Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

        //[Microsoft.AspNetCore.Mvc.ProducesResponseType
        //    (typeof(ViewModels.General.ErrorViewModel), Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        //public Microsoft.AspNetCore.Mvc.ActionResult<ViewModels.User.LoginResponseViewModel> Login(ViewModels.User.LoginRequestViewModel viewModel)
        //{
        //    ViewModels.User.LoginResponseViewModel loginResponseViewModel = 
        //        UserService.Login(loginRequestViewModel: viewModel);

        //    if(loginResponseViewModel==null)
        //    {
        //        return null;
        //    }

        //    return Ok(loginResponseViewModel);
        //}

        // *******************************
        //         LoginAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpPost(template: "LoginAsync")]

      //  [Microsoft.AspNetCore.Cors.EnableCors(policyName: Startup.OTHERS_CORS_POLICY)]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (typeof(ViewModels.User.LoginResponseViewModel),Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

        [Microsoft.AspNetCore.Mvc.ProducesResponseType
            (typeof(ViewModels.General.ErrorViewModel), Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ViewModels.User.LoginResponseViewModel>>
            LoginAsync(ViewModels.User.LoginRequestViewModel viewModel)
        {
            ViewModels.User.LoginResponseViewModel loginResponseViewModel = await
                UserService.LoginAsync(loginRequestViewModel: viewModel);

            if (loginResponseViewModel == null)
            {
                //Username and/or password is not correct!
                string strErrorMessage =
                     Resources.ErrorMessages.ErrorMessage3020_3030;

                return BadRequest(
                    new ViewModels.General.ErrorViewModel(message: strErrorMessage));
            }

            return Ok(loginResponseViewModel);
        }

        // *******************************
        //            GetAllAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Azx.Result<Models.User>>>> GetAllAsync()
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.User> result = new Result<Models.User>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.UserRepository.GetAllAsync();

                if (foundedEntities == null)
                {
                    //     result.SetData(null);
                    result.IsSuccessful = false;

                    //No information was found 
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3220);
                }
                else
                {

                    result.SetData(data: foundedEntities);
                    result.IsSuccessful = true;

                }
                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //   result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                return Ok(value: result);
            }
        }
        // *******************************
        //            GetByIdAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{id:Guid}")] //این دستور بهتر است 

        [Infrastructure.Attributes.Authorize]
        public async System.Threading.Tasks.Task
       <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.User>>> GetByIdAsync(System.Guid id)
        {
            Result<Models.User> result = new Result<Models.User>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserRepository.GetByIdAsync(id: id);

                if (foundedEntity == null)
                {
                    //    result.SetData(null);
                    result.IsSuccessful = false;

                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);
                }
                else
                {
                    result.SetData(data: foundedEntity);
                    result.IsSuccessful = true;

                }

                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //  result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                return Ok(value: result);
            }
        }

        // *******************************
        //         GetActiveAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "active")] //این دستور بهتر است 
        public async System.Threading.Tasks.Task
       <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Result<Models.User>>>> GetActiveAsync()
        {
            Result<Models.User> result = new Result<Models.User>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserRepository.GetActiveAsync();

                if (foundedEntity == null)
                {
                    //    result.SetData(null);
                    result.IsSuccessful = false;

                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);
                }
                else
                {
                    result.SetData(data: foundedEntity);
                    result.IsSuccessful = true;

                }

                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //  result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                return Ok(value: result);
            }
        }

        // *******************************
        //         GetByUserNameAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{username}")]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.User>>> GetByUserNameAsync(string username)
        {
            Result<Models.User> result = new Result<Models.User>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserRepository.GetByUserNameAsync(username: username);

                if (foundedEntity == null)
                {
                    //    result.SetData(null);
                    result.IsSuccessful = false;

                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);
                }
                else
                {
                    result.SetData(data: foundedEntity);
                    result.IsSuccessful = true;

                }

                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //  result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                return Ok(value: result);
            }
        }
        // *******************************
        //             PostAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Azx.Result<Models.User>>> PostAsync(Models.User user)
        {
            Result<Models.User> result = new Result<Models.User>();
            try
            {

                var remoteIpAddress = await HttpContext.GetRemoteIPAddressAsync();
                var newEntity =
                    new Models.User
                    {
                        Id = user.Id,
                        IsActive = user.IsActive,
                        CellPhoneNumber = user.CellPhoneNumber,
                        FullName = user.FullName,
                        GroupId = user.GroupId,
                        Password = user.Password,
                        RegisterIP = remoteIpAddress.ToString(),
                        RoleId = user.RoleId,
                        Type = user.Type,
                        Username = user.Username,
                        //UserImage=user.UserImage
                    };

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.UserRepository.InsertAsync(entity: newEntity);

                //Logger.LogTrace(typeof(ApplicationsController), "شیء را به ریپوزیتوری اضافه می‌کنم");

                await UnitOfWork.SaveAsync();

                //Logger.LogTrace(typeof(ApplicationsController), "یونیت آو ورک را ذخیره می‌کنم");

                result.SetData(data: newEntity);
                result.IsSuccessful = true;

                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //    Logger.LogError(typeof(ApplicationsController), ex.Message);

                //   result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                // "خطای ناشناخته‌ای صورت گرفته است لطفا با تیم پشتیبانی تماس حاصل فرمایید"

                //An unknown error occurred. Please contact administrator
                result.AddErrorMessage
                              (Resources.ErrorMessages.ErrorMessage3230);

                return Ok(value: result);
            }
        }
        // *******************************
        //             PutAsync
        // *******************************

        [Microsoft.AspNetCore.Mvc.HttpPut("{id:Guid}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.User>>> PutAsync(System.Guid id, Models.User user)
        {
            Result<Models.User> result = new Result<Models.User>();

            try
            {

                Models.User foundedEntity = await
                    UnitOfWork.UserRepository.GetByIdAsync(id: id);

                if (foundedEntity == null)
                {
                    //   result.SetData(null);
                    result.IsSuccessful = false;
                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);

                    return (Ok(value: result));
                }

                var remoteIpAddress = await HttpContext.GetRemoteIPAddressAsync();

                foundedEntity.Id = user.Id;
                foundedEntity.IsActive = user.IsActive;
                foundedEntity.CellPhoneNumber = user.CellPhoneNumber;
                foundedEntity.FullName = user.FullName;
                foundedEntity.GroupId = user.GroupId;
                foundedEntity.Password = user.Password;
                foundedEntity.RegisterIP = remoteIpAddress.ToString();
                foundedEntity.RoleId = user.RoleId;
                foundedEntity.Type = user.Type;
                foundedEntity.Username = user.Username;
                //UserImage=user.UserImage

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.UserRepository.UpdateAsync(entity: foundedEntity);

                //Logger.LogTrace(typeof(ApplicationsController), "شیء را به ریپوزیتوری اضافه می‌کنم");

                await UnitOfWork.SaveAsync();

                //Logger.LogTrace(typeof(ApplicationsController), "یونیت آو ورک را ذخیره می‌کنم");
                result.SetData(data: foundedEntity);
                result.IsSuccessful = true;

                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //Logger.LogError(typeof(ApplicationsController), ex.Message);


                //   result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                // "خطای ناشناخته‌ای صورت گرفته است لطفا با تیم پشتیبانی تماس حاصل فرمایید"

                //An unknown error occurred. Please contact administrator
                result.AddErrorMessage
                              (Resources.ErrorMessages.ErrorMessage3230);

                return Ok(value: result);
            }
        }
        // *******************************
        //       DeleteAsync
        // *******************************

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id:Guid}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<bool>>> DeleteAsync(Guid id)
        {
            Result<Models.User> result = new Result<Models.User>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                bool blnResult =
                    await UnitOfWork.UserRepository.DeleteByIdAsync(id: id);

                //Logger.LogTrace(typeof(ApplicationsController), "شیء را به ریپوزیتوری اضافه می‌کنم");
                if (blnResult == true)
                {
                    await UnitOfWork.SaveAsync();
                    //  result.SetData(null);
                    result.IsSuccessful = true;
                }
                else
                {
                    // result.SetData(null);
                    result.IsSuccessful = false;
                    // The requested information could not be deleted
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3240);

                    return (Ok(value: result));
                }
                //Logger.LogTrace(typeof(ApplicationsController), "یونیت آو ورک را ذخیره می‌کنم");

                return Ok(value: result);
            }
            catch (System.Exception ex)
            {
                //Logger.LogError(typeof(ApplicationsController), ex.Message);


                //    result.SetData(null);
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                // "خطای ناشناخته‌ای صورت گرفته است لطفا با تیم پشتیبانی تماس حاصل فرمایید"

                //An unknown error occurred. Please contact administrator
                result.AddErrorMessage
                              (Resources.ErrorMessages.ErrorMessage3230);

                return Ok(value: result);
            }
        }
    }
}
