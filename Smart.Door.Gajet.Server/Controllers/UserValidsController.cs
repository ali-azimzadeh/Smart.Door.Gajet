using Azx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Server.Controllers
{
    public class UserValidsController : Infrastructure.BaseApiControllerWithDatabase
    {
        public UserValidsController(Data.IUnitOfWork unitOfWork)
            : base(unitOfWork: unitOfWork)
        {
        }
        // *******************************
        //            GetAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Azx.Result<Models.UserValid>>>> GetAsync()
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.UserValid> result = new Result<Models.UserValid>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.UserValidRepository.GetAllAsync();

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
        //       GetByBuildingIdAsync
        // *******************************
        //دستور زیر اگر درخواست به همراه نام تابع باشد کار می کند ولی در غیر اینصورت پارامتر ورودی 0 نشان می دهد
        //[Microsoft.AspNetCore.Mvc.HttpGet(template: "{0}")]
        //http://localhost:34983/UserValids/getasync?id=32988734-a757-4172-ae43-0f589aef9697
        // *******************************
        //  [Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")] // این دستور هم درست کار می کند 
        //http://localhost:34983/UserValids/32988734-a757-4172-ae43-0f589aef9697
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{buildingid:Guid}")] //این دستور بهتر است 
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Result<Models.UserValid>>>> GetByBuildingIdAsync(System.Guid buildingid)
        {
            Result<Models.UserValid> result = new Result<Models.UserValid>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserValidRepository.GetByBuildingIdAsync(buildingid);

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
        //       GetByMobileNoAsync
        // *******************************

        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{mobileno}")] //این دستور بهتر است 
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.UserValid>>> GetByMobileNoAsync(string mobileno)
        {
            Result<Models.UserValid> result = new Result<Models.UserValid>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserValidRepository.GetByMobileNoAsync(mobileNo: mobileno);

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
        //  GetByBuildingId_MobileNoAsync
        // *******************************

        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{buildingId}/{mobileno}")] //این دستور بهتر است 
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.UserValid>>> GetByBuildingId_MobileNoAsync(Guid buildingId, string mobileno)
        {
            Result<Models.UserValid> result = new Result<Models.UserValid>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.UserValidRepository.GetByBuildingId_MobileNoAsync(buildingId: buildingId, mobileNo: mobileno);

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
                <Microsoft.AspNetCore.Mvc.ActionResult<Azx.Result<Models.UserValid>>> PostAsync(Models.UserValid userValid)
        {
            Result<Models.UserValid> result = new Result<Models.UserValid>();
            try
            {

                var newEntity =
                    new Models.UserValid
                    {
                        Id = userValid.Id,
                        UnitNo = userValid.UnitNo,
                        UserId = userValid.UserId,
                        IsActive = userValid.IsActive,
                        BuildingId = userValid.BuildingId,
                        ValidCellPhoneNumber = userValid.ValidCellPhoneNumber

                    };

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.UserValidRepository.InsertAsync(entity: newEntity);

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
        //اگر به شکل زیر نوشته شود کار نمی کند و درخواست وارد این اکشن نمی شود
        //        [Microsoft.AspNetCore.Mvc.HttpPut("{buildingId:Guid}/{mobileno:string}")]

        [Microsoft.AspNetCore.Mvc.HttpPut("{buildingId}/{mobileno}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.UserValid>>> PutAsync(System.Guid buildingId, string mobileno, Models.UserValid userValid)
        {
            Result<Models.UserValid> result = new Result<Models.UserValid>();

            try
            {
                //با این روش هم می توان کار کرد 
                //ActionResult<Result<Models.UserValid>> foundedEntity = await
                //    GetByBuildingId_MobileNoAsync(buildingId: buildingId, mobileno: mobileno);

                Models.UserValid foundedEntity = await
                    UnitOfWork.UserValidRepository.GetByBuildingId_MobileNoAsync(buildingId: buildingId, mobileNo: mobileno);

                if (foundedEntity == null)
                {
                    //   result.SetData(null);
                    result.IsSuccessful = false;
                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);

                    return (Ok(value: result));
                }

                foundedEntity.Id = userValid.Id;
                foundedEntity.UnitNo = userValid.UnitNo;
                foundedEntity.UserId = userValid.UserId;
                foundedEntity.IsActive = userValid.IsActive;
                foundedEntity.BuildingId = userValid.BuildingId;
                foundedEntity.ValidCellPhoneNumber = userValid.ValidCellPhoneNumber;


                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.UserValidRepository.UpdateAsync(entity: foundedEntity);

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

        [Microsoft.AspNetCore.Mvc.HttpDelete("{buildingId}/{mobileno}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<bool>>> DeleteAsync(Guid buildingId, string mobileno)
        {
            Result<Models.UserValid> result = new Result<Models.UserValid>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                bool blnResult =
                    await UnitOfWork.UserValidRepository.DeleteByBuildingId_MobileNoAsync(buildingId: buildingId, mobileno: mobileno);

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
