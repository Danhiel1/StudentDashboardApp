using System.Collections.Generic;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;

namespace StudentDashboardApp.Services
{
    public class NavigationHelper
    {
        private readonly NavigationFrame _frame;
        private readonly Dictionary<BarButtonItem, NavigationPage> _pageMap;

        public NavigationHelper(NavigationFrame frame, Dictionary<BarButtonItem, NavigationPage> pageMap)// khởi tạo hàm có tham số truyền vào để nhận diện các frame và page
        {
            _frame = frame; // đưa giá trị frame được truyền vào
            _pageMap = pageMap;// đư agias trị các page và các nút được truyền vào

            
            foreach (var btn in _pageMap.Keys) //duyệt qua từng phần tử nút trong page map vừa lưu và khi có dấu hiệu ấn thì hàm OnButtonClick sẽ được thực thi (_pageMap.Keys lấy tất cả các key có trong hashmap)
                btn.ItemClick+= OnButtonClick; // gắn thuộc tính sự kiện cho từng nút trong Dictionary vì thế kh cần sử dụng hàm sự kiện của form nữa chỉ cần khai bào trong load của form thôi nhó hiếu-chan
        }

        private void OnButtonClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item is BarButtonItem btn && _pageMap.TryGetValue(btn, out var page))// nếu bạn ấn vào nút dạng baritem đưa name của nút đó vào btn và trygetvalue kiểm tra xem xong hashmap Dictionary có tồn tại page tương ứng với name của button không, nếu có thì show page
            {
                ShowNavigationPage(page);
            }
        }

        public void ShowNavigationPage(NavigationPage page)
        {
            if (page == null) return; // nếu biến page chưa được gán giá trị của page nào tắt hàm
            _frame.Visible = true; // qua được phần điều kiện thì hiển thị lại frame
            _frame.SelectedPage = page;// và chọn page đc tham chiếu trong Dictionary
        }

        public void ShowEmptyPage(NavigationPage emptyPage) // cái này kh cần sài cx được nhưng muốn ngầu hơn thì sài cái này
        {
            if (emptyPage == null) return;
            _frame.Visible = true;
            _frame.SelectedPage = emptyPage;
        }
    }
}
