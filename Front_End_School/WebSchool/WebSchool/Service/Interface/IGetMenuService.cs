using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.Service.Interface
{
    public interface IGetMenuService
    {
        List<Menu> GetMenuController(MenuAction model);
    }
}
