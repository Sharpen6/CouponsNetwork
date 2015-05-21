var menuBar = ["home", "ManageCoupons", "ActiveCoupons", "Purchased", "CreateCoupon", "AddBusiness", "AddCategory", "AddInterest"];
function SwitchTo(divName) {
    for (var i = 0; i < menuBar.length; i++) {
        var e = document.getElementById(menuBar[i]);
        if (e!=null)
            if (divName == menuBar[i]) {
                e.style.display = 'block';
            }
            else {
                e.style.display = 'none';
            }
    }
}