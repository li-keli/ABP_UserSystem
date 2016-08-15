using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Cbd.Fgw.Application.PagedResult;

namespace Cbd.Fgw.Application.System.Menu.Dto
{
    public class MenuDtoOuput : IOutputDto
    {
    }

    public class MenuSearchOutputDto : IDataTableViewModelOutput<MenuDto>
    {
        public int Total { get; set; }
        public List<MenuDto> Rows { get; set; }
    }
}
