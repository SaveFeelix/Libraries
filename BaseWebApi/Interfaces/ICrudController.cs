using BaseWebApi.Result;
using Microsoft.AspNetCore.Mvc;

namespace BaseWebApi.Interfaces
{
    public interface ICrudController<TGetDto, in TCreateDto, in TUpdateDto>
    {
        Task<ActionResult<BaseResult<List<TGetDto>>>> All();
        Task<ActionResult<BaseResult<TGetDto>>> Get(int id);
        Task<ActionResult<BaseResult<TGetDto>>> Post(TCreateDto dto);
        Task<ActionResult<BaseResult<TGetDto>>> Put(int id, TUpdateDto dto);
        Task<ActionResult<BaseResult>> Delete(int id);
    }
}