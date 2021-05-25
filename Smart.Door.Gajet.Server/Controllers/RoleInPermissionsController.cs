using Azx;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Server.Controllers
{
    public class RoleInPermissionsController : Infrastructure.BaseApiControllerWithDatabase
    {
        public RoleInPermissionsController(Data.IUnitOfWork unitOfWork)
            : base(unitOfWork: unitOfWork)
        {
        }

        // *******************************
        //          GetAllAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<Azx.Result<Models.RoleInPermission>>>> GetAllAsync()
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.RoleInPermissionRepository.GetAllAsync();

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
            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.RoleInPermissionRepository.GetByIdAsync(id: id);

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
        //    GetByRoleId_MenuIdAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "{roleid}/{menuid}")] 
        public async System.Threading.Tasks.Task
       <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.Device>>> GetByRoleId_MenuIdAsync(System.Guid roleid,byte menuid)
        {
            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();

            try
            {
                var foundedEntity =
                    await UnitOfWork.RoleInPermissionRepository.GetByRoleId_MenuIdAsync(roleId:roleid,menuId:menuid);

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
        //          GetByRoleIdAsync
        // *******************************
        [Microsoft.AspNetCore.Mvc.HttpGet(template: "RoleId/{roleid:Guid}")]
        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Azx.Result<Models.RoleInPermission>>>> GetByRoleIdAsync(Guid roleid)
        {
            System.Threading.Thread.Sleep(2000);

            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();

            try
            {
                var foundedEntities =
                    await UnitOfWork.RoleInPermissionRepository.GetByRoleIdAsync(id:roleid);

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
                <Microsoft.AspNetCore.Mvc.ActionResult<Azx.Result<Models.RoleInPermission>>> PostAsync(Models.RoleInPermission  roleInPermission)
        {
            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();
            try
            {

                var newEntity =
                    new Models.RoleInPermission
                    {
                        Id = roleInPermission.Id,
                        MenuId = roleInPermission.MenuId,
                        RoleId = roleInPermission.RoleId,
                        IsActive = roleInPermission.IsActive,
                    };

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.RoleInPermissionRepository.InsertAsync(entity: newEntity);

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
                <Microsoft.AspNetCore.Mvc.ActionResult<Result<Models.RoleInPermission>>> PutAsync(System.Guid id, Models.RoleInPermission roleInPermission)
        {
            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();

            try
            {

                Models.RoleInPermission foundedEntity = await
                    UnitOfWork.RoleInPermissionRepository.GetByIdAsync(id: id);

                if (foundedEntity == null)
                {
                    //   result.SetData(null);
                    result.IsSuccessful = false;
                    //No information was found with this feature
                    result.AddErrorMessage
                        (Resources.ErrorMessages.ErrorMessage3200);

                    return (Ok(value: result));
                }

                foundedEntity.Id = roleInPermission.Id;
                foundedEntity.MenuId = roleInPermission.MenuId;
                foundedEntity.RoleId = roleInPermission.RoleId;
                foundedEntity.IsActive = roleInPermission.IsActive;


                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                await UnitOfWork.RoleInPermissionRepository.UpdateAsync(entity: foundedEntity);

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
            Result<Models.RoleInPermission> result = new Result<Models.RoleInPermission>();

            try
            {

                // Logger.LogTrace(typeof(ApplicationsController), "یک شیء ایجاد می‌کنم");

                bool blnResult =
                    await UnitOfWork.RoleInPermissionRepository.DeleteByIdAsync(id: id);

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
