namespace Cbd.Fgw.Application.System.Department.Dto {
    /// <summary>
    /// 企业列表异步树
    /// </summary>
    public class DepartmentTreeAsync {
        public int id { set; get; }
        public string name { set; get; }
        public bool open { set; get; }
        public bool isParent { set; get; }
    }
}
