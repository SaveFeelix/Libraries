using BaseWebApi.Result;
using Microsoft.AspNetCore.Mvc;

namespace BaseWebApi.Interfaces
{
    public interface ICrudController<TGetDto, in TCreateDto, in TUpdateDto>
    {
        Task<ActionResult<BaseResult<List<TGetDto>>>> All();
        Task<ActionResult<BaseResult<TGetDto>>> ById(int id);
        Task<ActionResult<BaseResult<TGetDto>>> Create(TCreateDto dto);
        Task<ActionResult<BaseResult<TGetDto>>> Update(int id, TUpdateDto dto);
        Task<ActionResult<BaseResult>> Delete(int id);
    }
}