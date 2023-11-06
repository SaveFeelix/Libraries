using BaseWebApi.Result;
using Microsoft.AspNetCore.Mvc;

namespace BaseWebApi.Interfaces
{
    public interface ICrudController<TAllResult, TIdResult, TCreateResult, TUpdateResult, TDeleteResult, in TCreateDto,
        in TUpdateDto>
    {
        Task<ActionResult<BaseResult<TAllResult>>> All();
        Task<ActionResult<BaseResult<TIdResult>>> ById(int id);
        Task<ActionResult<BaseResult<TCreateResult>>> Create(TCreateDto dto);
        Task<ActionResult<BaseResult<TUpdateResult>>> Update(int id, TUpdateDto dto);
        Task<ActionResult<BaseResult<TDeleteResult>>> Delete(int id);
    }
}