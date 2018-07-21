
'use strict'
angular.module('hotelBookingServiceModule').factory('DomesticHotelBookingServiceModelFactory', [function () {
    var DomesticHotelBookingServiceModelFactory = function (dhbs) {
        var _dhbs = this;
        if (!dhbs) {
            _dhbs.Id = null;
            _dhbs.HotelNameByLanguageS = [];
            _dhbs.Stars = null;
            _dhbs.Rate = null;
            _dhbs.FreeWifi = null;
            _dhbs.Address = null;
            _dhbs.Description = null;

            _dhbs.CityItem = {};

            _dhbs.HotelAccessibilityS = [];
            _dhbs.HotelFacilitiesS = [];
            _dhbs.HotelPhotosS = [];
            _dhbs.HotelRoomS = [];
            _dhbs.HotelCommentsS = [];

            _dhbs.selected = false;
            _dhbs.minPrice = null;
        }
        else
            _dhbs = dhbs;
    };
    return DomesticHotelBookingServiceModelFactory;
}]);

angular.module('hotelBookingServiceModule').factory('ReqHotelBookingServiceModelFactory', [function () {
    var ReqHotelBookingServiceModelFactory = function (dhbs) {
        var _dhbs = this;
        if (!dhbs) {

            _dhbs.Id = null;
            _dhbs.HotelItem = {};
        }
        else
            _dhbs = dhbs;
    };
    return ReqHotelBookingServiceModelFactory;
}]);

angular.module('hotelBookingServiceModule').factory('DomesticHotelBookingServiceFactory', ['$http', '$rootScope', 'DomesticHotelBookingServiceModelFactory', function ($http, $rootScope, DomesticHotelBookingServiceModelFactory) {
    var HotelData = {
        FillHotel: function () {
            var LsthotelData = [];
            var hotelData = new DomesticHotelBookingServiceModelFactory();

            hotelData.Id = 1;
            hotelData.HotelNameByLanguageS = [{ Id: 1, Name: "هتل الماس 2 مشهد" }];
            hotelData.Stars = 4;
            hotelData.Rate = 4.3;
            hotelData.FreeWifi = true;
            hotelData.Address = "مشهد - خیابان امام رضا - امام رضا 20";
            hotelData.Description = "هتل الماس 2 مشهد، هتلی 5 ستاره و بسیار لوکس است که می‌تواند اقامت خاطره‌انگیزی برای شما در پایتخت معنوی ایران رقم بزند. در هتل الماس 2، همه‌ی امکانات در بالاترین سطح فراهم آمده تا میهمانان لذت یک سفر واقعی و آسوده را تجربه کنند. مثلاً اتاق‌ها علاوه بر اینکه با تخت‌های راحت و تمیز مجهز شده‌اند، دکوراسیون بسیار زیبا و آرام‌بخشی نیز دارند تا هر بار که به مشهد مقدس سفر می‌کنید، انتخابی جز این هتل نداشته باشید. ضمناً رستوران‌های هتل نیز فوق‌العاده‌اند، رستوران گردان پانوراما با دید 360 درجه‌ای از شهر، رستوران فیروزه و کافه رستوران روف گاردن نیز، خیال‌تان را از بابت خورد و خوراک در سفر راحت می‌کنند. هر گاه نیز خسته یا بی‌حوصله شدید، کافی است به مجموعه‌ی آبی هتل بروید و تنی به آب بزنید، سالن اسپا و ماساژ هم می‌تواند کوفتگی‌های ناشی از سفر را از تن‌تان به در کند. به همه‌ی اینها یک بازارچه‌ی جمع و جور و شیک را نیز اضافه کنید که با ارائه کالاهای لوکس، شما را از چرخیدن در بازارها بی‌نیاز می‌کند.";
            hotelData.CityItem = { Id: 1, CityName: "مشهد", OriginIATACODE: null };

            hotelData.HotelAccessibilityS = [
                   {
                       Id: 1,
                       Title: "فاصله تا ورودی باب الرضا",
                       Distance: null,
                       TimeWithCar: 4,
                       TimeWithWalk: 15,

                       IsImportant: true,
                   },
                   {
                       Id: 2,
                       Title: "فاصله تا حرم امام رضا علیه السلام",
                       Distance: null,
                       TimeWithCar: 4,
                       TimeWithWalk: 20,

                       IsImportant: true,
                   },
                  {
                      Id: 3,
                      Title: " فاصله تا ایستگاه راه آهن شهر مشهد",
                      Distance: null,
                      TimeWithCar: 11,
                      TimeWithWalk: null,

                      IsImportant: true,
                  },
                  {
                      Id: 4,
                      Title: " فاصله تا فرودگاه مشهد",
                      Distance: null,
                      TimeWithCar: 18,
                      TimeWithWalk: null,

                      IsImportant: true,
                  },
                 {
                     Id: 5,
                     Title: "فاصله تا نمایشگاه بین المللی مشهد",
                     Distance: null,
                     TimeWithCar: 30,
                     TimeWithWalk: null,

                     IsImportant: false,
                 },
                {
                    Id: 6,
                    Title: "فاصله تا پایانه مسافربری مشهد",
                    Distance: null,
                    TimeWithCar: 8,
                    TimeWithWalk: null,

                    IsImportant: true,
                },
            ];
            hotelData.HotelFacilitiesS = [
                {
                    Id: 1,
                    FacilitiesItem: {
                        Id: 1,
                        FacilitiesPersianName: "اینترنت",
                    },
                    IsImportant: true,
                },
                {
                    Id: 2,
                    FacilitiesItem: {
                        Id: 2,
                        FacilitiesPersianName: "رستوران",
                    },
                    IsImportant: true,
                },
                {
                    Id: 3,
                    FacilitiesItem: {
                        Id: 3,
                        FacilitiesPersianName: "کافی شاپ",
                    }
                            ,
                    IsImportant: false,
                },
                {
                    Id: 4,
                    FacilitiesItem: {
                        Id: 4,
                        FacilitiesPersianName: "آسانسور",
                    }
                            ,
                    IsImportant: true,
                },
                {
                    Id: 5,
                    FacilitiesItem: {
                        Id: 5,
                        FacilitiesPersianName: "استخر، سونا و جکوزی",
                    }
                            ,
                    IsImportant: true,
                },
                {
                    Id: 6,
                    FacilitiesItem: {
                        Id: 6,
                        FacilitiesPersianName: "تاکسی سرویس",
                    }
                            ,
                    IsImportant: false,
                },
                {
                    Id: 7,
                    FacilitiesItem: {
                        Id: 7,
                        FacilitiesPersianName: "پارکینگ",
                    }
                            ,
                    IsImportant: true,
                },
              {
                  Id: 8,
                  FacilitiesItem: {
                      Id: 8,
                      FacilitiesPersianName: "خشکشویی",
                  },
                  IsImportant: false,
              },
            {
                Id: 9,
                FacilitiesItem: {
                    Id: 9,
                    FacilitiesPersianName: "کافی",
                },
                IsImportant: false,
            }];
            hotelData.HotelPhotosS = [{
                Id: 1,
                FileItem: {
                    Id: 1,
                    FileUrl: "https://images.jabama.ir/17322",
                    FileName: "هتل الماس 2 مشهد",
                },
                Description: null,
            }];
            hotelData.HotelRoomS = [
                {
                    Id: 1,
                    HotelRoomBedItem: {
                        Id: 1,
                        BedName: "تخت دبل",
                    },
                    HotelRoomTypeItem: {
                        Id: 1,
                        Name: "سویيت جونيور",
                        Description: null,
                    },
                    RoomCount: 8,
                    Dimension: null,
                    MaxAdults: 2,
                    MaxChildren: null,
                    MaxGuests: null,
                    ChildNum: null,
                    ChildAge: null,
                    HasBreakfast: true,
                    HasLunch: true,
                    HasDinner: false,
                    TimeIn: null,
                    TimeOut: null,
                    ReqRoomCount: null,
                    ActiveNightPriceItem: {
                        Id: 1,
                        Price: 9540000,
                    },
                    selected: false,
                },
            {
                Id: 2,
                HotelRoomBedItem: {
                    Id: 2,
                    BedName: "تخت دبل",
                },
                HotelRoomTypeItem: {
                    Id: 2,
                    Name: "اتاق رویال دو تخته",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 2,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 2,
                    Price: 30540000,
                },
                selected: false,
            },
    {
        Id: 3,
        HotelRoomBedItem: {
            Id: 3,
            BedName: "تخت دبل",
        },
        HotelRoomTypeItem: {
            Id: 3,
            Name: "اتاق رویال دو تخته",
            Description: null,
        },
        RoomCount: 8,
        Dimension: null,
        MaxAdults: 2,
        MaxChildren: null,
        MaxGuests: null,
        ChildNum: null,
        ChildAge: null,
        HasBreakfast: true,
        HasLunch: false,
        HasDinner: false,
        TimeIn: null,
        TimeOut: null,
        ReqRoomCount: null,
        ActiveNightPriceItem: {
            Id: 3,
            Price: 10540000,
        },
        selected: false,
    },
    {
        Id: 4,
        HotelRoomBedItem: {
            Id: 4,
            BedName: "تخت توئین",
        },
        HotelRoomTypeItem: {
            Id: 4,
            Name: "اتاق دو تخته",
            Description: null,
        },
        RoomCount: 8,
        Dimension: null,
        MaxAdults: 3,
        MaxChildren: null,
        MaxGuests: null,
        ChildNum: null,
        ChildAge: null,
        HasBreakfast: true,
        HasLunch: false,
        HasDinner: false,
        TimeIn: null,
        TimeOut: null,
        ReqRoomCount: null,
        ActiveNightPriceItem: {
            Id: 4,
            Price: 5420000,
        },
        selected: false,
    },
            {
                Id: 5,
                HotelRoomBedItem: {
                    Id: 5,
                    BedName: "",
                },
                HotelRoomTypeItem: {
                    Id: 5,
                    Name: "سوییت لاکچری",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 4,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 5,
                    Price: 9540000,
                },
                selected: false,
            },
            {
                Id: 6,
                HotelRoomBedItem: {
                    Id: 6,
                    BedName: "",
                },
                HotelRoomTypeItem: {
                    Id: 6,
                    Name: "اتاق دوتخته رویال خانواده",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 2,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 6,
                    Price: 20540000,
                },
                selected: false,
            }
            ];

            TotalPrice: null,
            LsthotelData.push(hotelData);

            var hotelData = new DomesticHotelBookingServiceModelFactory();

            hotelData.Id = 2;
            hotelData.HotelNameByLanguageS = [{ Id: 1, Name: "هتل مجلل درویشی مشهد" }];
            hotelData.Stars = 5;
            hotelData.Rate = 4.3;
            hotelData.FreeWifi = true;
            hotelData.Address = "مشهد - خیابان امام رضا - بین خیابان امام رضا 24 و 26";
            hotelData.Description = "هتل الماس 2 مشهد، هتلی 5 ستاره و بسیار لوکس است که می‌تواند اقامت خاطره‌انگیزی برای شما در پایتخت معنوی ایران رقم بزند. در هتل الماس 2، همه‌ی امکانات در بالاترین سطح فراهم آمده تا میهمانان لذت یک سفر واقعی و آسوده را تجربه کنند. مثلاً اتاق‌ها علاوه بر اینکه با تخت‌های راحت و تمیز مجهز شده‌اند، دکوراسیون بسیار زیبا و آرام‌بخشی نیز دارند تا هر بار که به مشهد مقدس سفر می‌کنید، انتخابی جز این هتل نداشته باشید. ضمناً رستوران‌های هتل نیز فوق‌العاده‌اند، رستوران گردان پانوراما با دید 360 درجه‌ای از شهر، رستوران فیروزه و کافه رستوران روف گاردن نیز، خیال‌تان را از بابت خورد و خوراک در سفر راحت می‌کنند. هر گاه نیز خسته یا بی‌حوصله شدید، کافی است به مجموعه‌ی آبی هتل بروید و تنی به آب بزنید، سالن اسپا و ماساژ هم می‌تواند کوفتگی‌های ناشی از سفر را از تن‌تان به در کند. به همه‌ی اینها یک بازارچه‌ی جمع و جور و شیک را نیز اضافه کنید که با ارائه کالاهای لوکس، شما را از چرخیدن در بازارها بی‌نیاز می‌کند.";
            hotelData.CityItem = { Id: 1, CityName: "مشهد", OriginIATACODE: null };

            hotelData.HotelAccessibilityS = [
                   {
                       Id: 1,
                       Title: "فاصله تا ورودی باب الرضا",
                       Distance: null,
                       TimeWithCar: 4,
                       TimeWithWalk: 15,

                       IsImportant: false,
                   },
                   {
                       Id: 2,
                       Title: "فاصله تا حرم امام رضا علیه السلام",
                       Distance: null,
                       TimeWithCar: 4,
                       TimeWithWalk: 20,

                       IsImportant: true,
                   },
                  {
                      Id: 3,
                      Title: " فاصله تا ایستگاه راه آهن شهر مشهد",
                      Distance: null,
                      TimeWithCar: 11,
                      TimeWithWalk: null,

                      IsImportant: true,
                  },
                  {
                      Id: 4,
                      Title: " فاصله تا فرودگاه مشهد",
                      Distance: null,
                      TimeWithCar: 18,
                      TimeWithWalk: null,

                      IsImportant: true,
                  },
                 {
                     Id: 5,
                     Title: "فاصله تا نمایشگاه بین المللی مشهد",
                     Distance: null,
                     TimeWithCar: 30,
                     TimeWithWalk: null,

                     IsImportant: false,
                 },
                {
                    Id: 6,
                    Title: "فاصله تا پایانه مسافربری مشهد",
                    Distance: null,
                    TimeWithCar: 8,
                    TimeWithWalk: null,

                    IsImportant: true,
                },
            ];
            hotelData.HotelFacilitiesS = [
                {
                    Id: 1,
                    FacilitiesItem: {
                        Id: 1,
                        FacilitiesPersianName: "اینترنت",
                    },
                    IsImportant: true,
                },
                {
                    Id: 2,
                    FacilitiesItem: {
                        Id: 2,
                        FacilitiesPersianName: "رستوران",
                    },
                    IsImportant: true,
                },
                {
                    Id: 3,
                    FacilitiesItem: {
                        Id: 3,
                        FacilitiesPersianName: "کافی شاپ",
                    }
                            ,
                    IsImportant: false,
                },
                {
                    Id: 4,
                    FacilitiesItem: {
                        Id: 4,
                        FacilitiesPersianName: "آسانسور",
                    }
                            ,
                    IsImportant: true,
                },
                {
                    Id: 5,
                    FacilitiesItem: {
                        Id: 5,
                        FacilitiesPersianName: "استخر، سونا و جکوزی",
                    }
                            ,
                    IsImportant: true,
                },
                {
                    Id: 6,
                    FacilitiesItem: {
                        Id: 6,
                        FacilitiesPersianName: "تاکسی سرویس",
                    }
                            ,
                    IsImportant: false,
                },
                {
                    Id: 7,
                    FacilitiesItem: {
                        Id: 7,
                        FacilitiesPersianName: "پارکینگ",
                    }
                            ,
                    IsImportant: true,
                },
              {
                  Id: 8,
                  FacilitiesItem: {
                      Id: 8,
                      FacilitiesPersianName: "خشکشویی",
                  },
                  IsImportant: false,
              }];
            hotelData.HotelPhotosS = [{
                Id: 1,
                FileItem: {
                    Id: 1,
                    FileUrl: "https://images.jabama.ir/21753",
                    FileName: "هتل الماس 2 مشهد",
                },
                Description: null,
            }];
            hotelData.HotelRoomS = [
                {
                    Id: 1,
                    HotelRoomBedItem: {
                        Id: 1,
                        BedName: "تخت دبل",
                    },
                    HotelRoomTypeItem: {
                        Id: 1,
                        Name: "سویيت جونيور",
                        Description: null,
                    },
                    RoomCount: 8,
                    Dimension: null,
                    MaxAdults: 2,
                    MaxChildren: null,
                    MaxGuests: null,
                    ChildNum: null,
                    ChildAge: null,
                    HasBreakfast: true,
                    HasLunch: true,
                    HasDinner: false,
                    TimeIn: null,
                    TimeOut: null,
                    ReqRoomCount: null,
                    ActiveNightPriceItem: {
                        Id: 1,
                        Price: 9540000,
                    },
                    selected: false,
                },
            {
                Id: 2,
                HotelRoomBedItem: {
                    Id: 2,
                    BedName: "تخت دبل",
                },
                HotelRoomTypeItem: {
                    Id: 2,
                    Name: "اتاق رویال دو تخته",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 2,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 2,
                    Price: 30540000,
                },
                selected: false,
            },
            {
                Id: 3,
                HotelRoomBedItem: {
                    Id: 3,
                    BedName: "تخت دبل",
                },
                HotelRoomTypeItem: {
                    Id: 3,
                    Name: "اتاق رویال دو تخته",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 2,
                MaxChildren: null,
                MaxGuests: null,
                TimeIn: null,
                TimeOut: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 3,
                    Price: 10540000,
                },
                selected: false,
            },
            {
                Id: 4,
                HotelRoomBedItem: {
                    Id: 4,
                    BedName: "تخت توئین",
                },
                HotelRoomTypeItem: {
                    Id: 4,
                    Name: "اتاق دو تخته",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 3,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 4,
                    Price: 5420000,
                },
                selected: false,
            },
            {
                Id: 5,
                HotelRoomBedItem: {
                    Id: 5,
                    BedName: "",
                },
                HotelRoomTypeItem: {
                    Id: 5,
                    Name: "سوییت لاکچری",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 4,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 5,
                    Price: 9540000,
                },
                selected: false,
            },
            {
                Id: 6,
                HotelRoomBedItem: {
                    Id: 6,
                    BedName: "",
                },
                HotelRoomTypeItem: {
                    Id: 6,
                    Name: "اتاق دوتخته رویال خانواده",
                    Description: null,
                },
                RoomCount: 8,
                Dimension: null,
                MaxAdults: 2,
                MaxChildren: null,
                MaxGuests: null,
                ChildNum: null,
                ChildAge: null,
                HasBreakfast: true,
                HasLunch: false,
                HasDinner: false,
                TimeIn: null,
                TimeOut: null,
                ReqRoomCount: null,
                ActiveNightPriceItem: {
                    Id: 6,
                    Price: 20540000,
                },
                selected: false,
            }
            ];

            TotalPrice: null,
            LsthotelData.push(hotelData);

            return LsthotelData;
        },
    };

    var dhbsFactory = {
    };
    //#region Private Event
    //#rendegion

    return { dhbsFactory: dhbsFactory, HotelData: HotelData }
}]);