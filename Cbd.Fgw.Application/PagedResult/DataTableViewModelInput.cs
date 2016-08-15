using Abp.Application.Services.Dto;

namespace Cbd.Fgw.Application.PagedResult {
    /// <summary>
    /// 分页视图模型
    /// </summary>
    public interface IDataTableViewModelInput : IInputDto {
        /// <summary>
        /// 排序方式 asc；desc
        /// </summary>
        string Order { set; get; }
        /// <summary>
        /// 目前位置
        /// </summary>
        int Offset { set; get; }
        /// <summary>
        /// 每页行数
        /// </summary>
        int Limit { set; get; }
    }
}
