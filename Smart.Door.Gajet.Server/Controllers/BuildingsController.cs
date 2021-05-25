using Azx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Server.Controllers
{
    public class BuildingsController : Infrastructure.BaseApiControllerWithDatabase
    {
        public BuildingsController(Data.IUnitOfWork unitOfWork) : base(unitOfWork: unitOfWork)
        {
        }

        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Azx.Result<Models.Building>>>> GetAsync()
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.Building> result = new Result<Models.Building>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.BuildingRepository.GetAllAsync();

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

        // *******************************
        //دستور زیر اگر درخواست به همراه نام تابع باشد کار می کند ولی در غیر اینصورت پارامتر ورودی 0 نشان می دهد
        //[Microsoft.AspNetCore.Mvc.HttpGet(template: "{0}")]
        //http://localhost:34983/buildings/getasync?id=32988734-a757-4172-ae43-0f589aef9697
        // *******************************
        //  [Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")] // این دستور هم درست کار می کند 
        //http://localhost:34983/buildings/32988734-a757-4172-ae43-0f589aef9697
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{id:Guid}")] //این دستور بهتر است 
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Building>>> GetAsync(System.Guid id)
        {
            Result<Models.Building> result = new Result<Models.Building>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.BuildingRepository.GetByIdAsync(id);

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
                    if (foundedEntity.IsActive == false)
                    {
                        //     result.SetData(null);
                        result.IsSuccessful = false;

                        //This information cannot be accessed
                        result.AddErrorMessage
                            (Resources.ErrorMessages.ErrorMessage3210);
                    }
                    else
                    {
                        result.SetData(data: foundedEntity);
                        result.IsSuccessful = true;
                    }
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

        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Azx.Result<Models.Building>>> PostAsync(Models.Building building)
        {
            Result<Models.Building> result = new Result<Models.Building>();
            try
            {

                var newEntity =
                    new Models.Building
                    {
                        Id = building.Id,
                        IsActive = building.IsActive,
                        UnitsCount = building.UnitsCount,
                        FloorsCount = building.FloorsCount,
                        BuildingName = building.BuildingName,
                        ManagerUnitNo = building.ManagerUnitNo,
                        ManagerFullName = building.ManagerFullName,
                        ManagerCellPhoneNumber = building.ManagerCellPhoneNumber,

                    };

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.BuildingRepository.InsertAsync(entity: newEntity);

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

        // *******************************
        //put نحوه ی درخواست متد 
        //http://localhost:34983/buildings/32988734-a757-4172-ae43-0f589aef9698
        [Microsoft.AspNetCore.Mvc.HttpPut("{id:Guid}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Building>>> PutAsync(System.Guid id, Models.Building building)
        {
            Result<Models.Building> result = new Result<Models.Building>();

            try
            {

                Models.Building foundedEntity = await
                    UnitOfWork.BuildingRepository.GetByIdAsync(id: building.Id);

                if (foundedEntity == null)
                {
                    //   result.SetData(null);
                    result.IsSuccessful = false;
                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);

                    return (Ok(value: result));
                }

                foundedEntity.IsActive = building.IsActive;
                foundedEntity.UnitsCount = building.UnitsCount;
                foundedEntity.FloorsCount = building.FloorsCount;
                foundedEntity.BuildingName = building.BuildingName;
                foundedEntity.ManagerUnitNo = building.ManagerUnitNo;
                foundedEntity.ManagerFullName = building.ManagerFullName;
                foundedEntity.ManagerCellPhoneNumber = building.ManagerCellPhoneNumber;


                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.BuildingRepository.UpdateAsync(entity: foundedEntity);

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

        // *******************************
        // با شناسه Delete نحوه ی درخواست متد 
        //http://localhost:34983/buildings/32988734-a757-4172-ae43-0f589aef9698
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id:Guid}")]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<bool>> DeleteAsync(Guid id)
        {
            Result<Models.Building> result = new Result<Models.Building>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                bool blnResult =
                    await UnitOfWork.BuildingRepository.DeleteByIdAsync(id: id);

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
        // *******************************

        // *******************************
        // بدون شناسه Delete نحوه ی درخواست متد 
        //http://localhost:34983/buildings
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult> DeleteAsync(Models.Building entity)
        {
            Result<Models.Building> result = new Result<Models.Building>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.BuildingRepository.DeleteAsync(entity);

                //Logger.LogTrace(typeof(ApplicationsController), "شیء را به ریپوزیتوری اضافه می‌کنم");

                await UnitOfWork.SaveAsync();
                //   result.SetData(null);
                result.IsSuccessful = true;

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
        // *******************************
    }
}
