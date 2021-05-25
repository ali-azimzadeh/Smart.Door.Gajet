using Azx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Server.Controllers
{
    public class DevicesController : Infrastructure.BaseApiControllerWithDatabase
    {
        public DevicesController(Data.IUnitOfWork unitOfWork)
            : base(unitOfWork: unitOfWork)
        {
        }

        // *******************************
        //          GetAllAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Azx.Result<Models.Device>>>> GetAllAsync()
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.Device> result = new Result<Models.Device>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.DeviceRepository.GetAllAsync();

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
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.DeviceRepository.GetByIdAsync(id: id);

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
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "active")]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<Result<Models.Device>>>> GetActiveAsync()
        {
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.DeviceRepository.GetActiveAsync();

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
        //      GetByBuildingIdAsync
        // *******************************
        //حتما باید نام پارامتر روتینگ با نام پارامتر ورودی تابع یکی باشد
//        [Microsoft.AspNetCore.Mvc.HttpGet(template: "building/{id}")]

        [Microsoft.AspNetCore.Mvc.HttpGet(template: "building/{buildingid}")]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Device>>> GetByBuildingIdAsync(Guid buildingid)
        {
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.DeviceRepository.GetByBuildingIdAsync(id: buildingid);

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
        //      GetBySerialNoAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{serialNo}")]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Device>>> GetBySerialNoAsync(string serialNo)
        {
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.DeviceRepository.GetBySerialNoAsync(serialNo: serialNo);

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
        //      GetBySimcardNoAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "simcard/{simcardNo}")]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Device>>> GetBySimcardNoAsync(string simcardNo)
        {
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.DeviceRepository.GetBySimcardNoAsync(simcardNo: simcardNo);

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
        //          PostAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async System.Threading.Tasks.Task
                <Microsoft.AspNetCore.Mvc.ActionResult<Azx.Result<Models.Device>>> PostAsync(Models.Device Device)
        {
            Result<Models.Device> result = new Result<Models.Device>();
            try
            {

                var newEntity =
                    new Models.Device
                    {
                        Id = Device.Id,
                        IsActive = Device.IsActive,
                        SerialNo = Device.SerialNo,
                        SimcardNo = Device.SimcardNo,
                        Frequency = Device.Frequency,
                        BuildingId = Device.BuildingId,
                        DeviceModel = Device.DeviceModel,
                    };

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.DeviceRepository.InsertAsync(entity: newEntity);

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
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Device>>> PutAsync(System.Guid id, Models.Device Device)
        {
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {

                Models.Device foundedEntity = await
                    UnitOfWork.DeviceRepository.GetByIdAsync(id: id);

                if (foundedEntity == null)
                {
                    //   result.SetData(null);
                    result.IsSuccessful = false;
                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);

                    return (Ok(value: result));
                }

                foundedEntity.Id = Device.Id;
                foundedEntity.IsActive = Device.IsActive;
                foundedEntity.SerialNo = Device.SerialNo;
                foundedEntity.SimcardNo = Device.SimcardNo;
                foundedEntity.Frequency = Device.Frequency;
                foundedEntity.BuildingId = Device.BuildingId;
                foundedEntity.DeviceModel = Device.DeviceModel;

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.DeviceRepository.UpdateAsync(entity: foundedEntity);

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
            Result<Models.Device> result = new Result<Models.Device>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                bool blnResult =
                    await UnitOfWork.DeviceRepository.DeleteByIdAsync(id: id);

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
