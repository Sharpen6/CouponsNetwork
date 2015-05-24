var menuBar = ["home", "ManageCoupons", "ActiveCoupons", "Purchased",
    "FindCoupon", "ShowBusinesses", "CreateCoupon","AddCity","RemoveCoupon",
    "AddBusiness", "AddCategory", "AddInterest","DeleteBusiness"];

function SwitchTo(divName) {
    if (divName == 'prevDiv')
        divName = localStorage["lastDiv"];
    else
        localStorage["lastDiv"] = divName;

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