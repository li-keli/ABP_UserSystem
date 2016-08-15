using AutoMapper;
using System.Linq;
using Abp.AutoMapper;
using Cbd.Fgw.Core.IRepository;
using Abp.Collections.Extensions;
using System.Collections.Generic;
using Cbd.Fgw.Application.System.Menu.Dto;

namespace Cbd.Fgw.Application.System.Menu {
    public class MenuService : FgwAppServiceBase, IMenuService {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository) {
            _menuRepository = menuRepository;
        }

        public List<MenuDto> GetAll() {
            var menus = _menuRepository.GetAllList(m => !m.IsRoot);
            Mapper.CreateMap<Core.System.Menu, MenuDto>();

            return menus.MapTo<List<MenuDto>>();
        }

        public Core.System.Menu GetMenu(int id) {
            return _menuRepository.Get(id);
        }

        public MenuDto Get(int id) {
            var menu = _menuRepository.Get(id);
            Mapper.CreateMap<Core.System.Menu, MenuDto>();
            return menu.MapTo<MenuDto>();
        }

        public MenuSearchOutputDto Get(MenuSearchInputDto input) {
            var menus = _menuRepository.GetAllList();
            var count = menus.Count;
            menus.WhereIf(!string.IsNullOrWhiteSpace(input.MenuName), m => m.MenuName.Contains(input.MenuName));
            menus = menus.Skip(input.Offset).Take(input.Limit).ToList();
            Mapper.CreateMap<Core.System.Menu, MenuDto>();

            return new MenuSearchOutputDto { Total = count, Rows = menus.MapTo<List<MenuDto>>() };
        }

        public void Create(MenuCreateInputDto input) {
            var menu = input.MapTo<Core.System.Menu>();
            _menuRepository.Insert(menu);
        }

        public void Edit(MenuEditInputDto input) {
            var menu = input.MapTo<Core.System.Menu>();
            _menuRepository.Update(menu);
        }

        public void Delete(int id) {
            _menuRepository.Delete(id);
        }
    }
}
