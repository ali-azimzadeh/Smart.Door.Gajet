using Azx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Server.Controllers
{
    public class UserPasswordHistoriesController : Infrastructure.BaseApiControllerWithDatabase
    {
        public UserPasswordHistoriesController(Data.IUnitOfWork unitOfWork)
            : base(unitOfWork: unitOfWork)
        {
        }

        // *******************************
        //          GetAllAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Azx.Result<Models.UserPasswordHistory>>>> GetAllAsync()
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.UserPasswordHistory> result = new Result<Models.UserPasswordHistory>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.UserPasswordHistoryRepository.GetAllAsync();

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
        //          GetByIdAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{id:Guid}")] //این دستور بهتر است 
        public async System.Threading.Tasks.Task
       <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Device>>> GetByIdAsync(System.Guid id)
        {
            Result<Models.UserPasswordHistory> result = new Result<Models.UserPasswordHistory>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserPasswordHistoryRepository.GetByIdAsync(id: id);

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
        //      GetByUserIdAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet("userid/{userid:Guid}")]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Azx.Result<Models.UserPasswordHistory>>>> GetByUserIdAsync(Guid userid)
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.UserPasswordHistory> result = new Result<Models.UserPasswordHistory>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.UserPasswordHistoryRepository.GetByUserIdAsync(id: userid);

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
        //          PostAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Azx.Result<Models.UserPasswordHistory>>> PostAsync(Models.UserPasswordHistory userPasswordHistory)
        {
            Result<Models.UserPasswordHistory> result = new Result<Models.UserPasswordHistory>();
            try
            {

                var newEntity =
                    new Models.UserPasswordHistory
                    {
                        Id = userPasswordHistory.Id,
                        UserId = userPasswordHistory.UserId,
                        Password = userPasswordHistory.Password,
                        IsActive = userPasswordHistory.IsActive,
                    };

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.UserPasswordHistoryRepository.InsertAsync(entity: newEntity);

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
        //           PutAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpPut("{id:Guid}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.UserPasswordHistory>>> PutAsync(System.Guid id, Models.UserPasswordHistory userPasswordHistory)
        {
            Result<Models.UserPasswordHistory> result = new Result<Models.UserPasswordHistory>();

            try
            {

                Models.UserPasswordHistory foundedEntity = await
                    UnitOfWork.UserPasswordHistoryRepository.GetByIdAsync(id: id);

                if (foundedEntity == null)
                {
                    //   result.SetData(null);
                    result.IsSuccessful = false;
                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);

                    return (Ok(value: result));
                }

                foundedEntity.Id = userPasswordHistory.Id;
                foundedEntity.UserId = userPasswordHistory.UserId;
                foundedEntity.Password = userPasswordHistory.Password;
                foundedEntity.IsActive = userPasswordHistory.IsActive;


                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.UserPasswordHistoryRepository.UpdateAsync(entity: foundedEntity);

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
        //       DeleteByIdAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id:Guid}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<bool>>> DeleteAsync(Guid id)
        {
            Result<Models.UserPasswordHistory> result = new Result<Models.UserPasswordHistory>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                bool blnResult =
                    await UnitOfWork.UserPasswordHistoryRepository.DeleteByIdAsync(id: id);

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
