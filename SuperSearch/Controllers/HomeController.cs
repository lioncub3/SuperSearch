﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperSearch.Models;

namespace SuperSearch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<SearchObject> searchObjects = new List<SearchObject> {
                new SearchObject() { Name = "Bill Gates", Description = "is an American business magnate, investor, author, philanthropist, and humanitarian. He is best known as the principal founder of Microsoft Corporation. During his career at Microsoft, Gates held the positions of chairman, CEO and chief software architect, while also being the largest individual shareholder until May 2014.", PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Bill_Gates_July_2014.jpg/220px-Bill_Gates_July_2014.jpg" },
                new SearchObject() { Name = "Apple", Description = "Apple Inc. is an American multinational technology company headquartered in Cupertino, California, that designs, develops, and sells consumer electronics, computer software, and online services. It is considered one of the Big Four tech companies along with Amazon, Google, and Facebook.", PhotoUrl = "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?201606271147" },
                new SearchObject() { Name = "Sonic the Hedgehog", Description = "Sonic the Hedgehog (ソニック・ザ・ヘッジホッグ Sonikku za Hejjihoggu?, born 23 June[8]) is Sega's mascot and the eponymous protagonist of the Sonic the Hedgehog series. He is an anthropomorphic hedgehog born with the ability to run faster than the speed of sound, hence his name, and possesses lightning fast reflexes to match. As his species implies, Sonic can also roll up into a concussive ball, primarily to attack enemies.", PhotoUrl = "https://vignette.wikia.nocookie.net/sonic/images/2/2d/TSR_Sonic.png/revision/latest/scale-to-width-down/319?cb=20190410054019" },
                new SearchObject() { Name = "Ecology", Description = "", PhotoUrl = "data:image/jpeg;base64,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" },
                new SearchObject() { Name = "Stepan Bandera", Description = "Stepan Andriyovych Bandera (Ukrainian: Степан Андрійович Бандера, Polish: Stepan Andrijowycz Bandera; 1 January 1909 – 15 October 1959) was a head of a militant wing of the Ukrainian independence movement,[1][2] and a leader of the terrorist activity of Ukrainian nationalists.[1]", PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/SBandera-colour.jpg/220px-SBandera-colour.jpg" },
            };

            return View(searchObjects);
        }

        [HttpGet]
        public IActionResult Index(string Name)
        {
            List<SearchObject> searchObjects = new List<SearchObject> {
                new SearchObject() { Name = "Bill Gates", Description = "is an American business magnate, investor, author, philanthropist, and humanitarian. He is best known as the principal founder of Microsoft Corporation. During his career at Microsoft, Gates held the positions of chairman, CEO and chief software architect, while also being the largest individual shareholder until May 2014.", PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/01/Bill_Gates_July_2014.jpg/220px-Bill_Gates_July_2014.jpg" },
                new SearchObject() { Name = "Apple", Description = "Apple Inc. is an American multinational technology company headquartered in Cupertino, California, that designs, develops, and sells consumer electronics, computer software, and online services. It is considered one of the Big Four tech companies along with Amazon, Google, and Facebook.", PhotoUrl = "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?201606271147" },
                new SearchObject() { Name = "Sonic the Hedgehog", Description = "Sonic the Hedgehog (ソニック・ザ・ヘッジホッグ Sonikku za Hejjihoggu?, born 23 June[8]) is Sega's mascot and the eponymous protagonist of the Sonic the Hedgehog series. He is an anthropomorphic hedgehog born with the ability to run faster than the speed of sound, hence his name, and possesses lightning fast reflexes to match. As his species implies, Sonic can also roll up into a concussive ball, primarily to attack enemies.", PhotoUrl = "https://vignette.wikia.nocookie.net/sonic/images/2/2d/TSR_Sonic.png/revision/latest/scale-to-width-down/319?cb=20190410054019" },
                new SearchObject() { Name = "Ecology", Description = "", PhotoUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxIQEhUSEhIWFRUVGBkaGBgYGBUZFxcZGBgXHRgXHxoZHSkgGR8mHxoZIjMhJSkrLi4vGB8zODMtNygtLisBCgoKDg0OGBAQFy0dHR0tLS0tLS0tKy0tLSstLS0tLS0tLS0tLSstLS0tLSstLS0tLS0tLS0tLS0tLS0tKy0tLf/AABEIAOEA4AMBIgACEQEDEQH/xAAcAAACAgMBAQAAAAAAAAAAAAAABQQGAQMHAgj/xABBEAACAQMCBAQDBQcDAwIHAAABAhEAAyEEEgUxQVEGEyJhMnGBByNCkaEUM1JiscHwgpLRcuHxQ7IVFyQ0U3Oi/8QAGAEBAQEBAQAAAAAAAAAAAAAAAAECAwT/xAAiEQEBAQEAAgIDAQEBAQAAAAAAARECEiExQQMTUWEycSL/2gAMAwEAAhEDEQA/AOH0UUVVZorFFAUUUUBRRRQZoooioCimfCPD2r1ZA0+nuXZ6qp24/mOP1q16L7KdaYN97GnH87gsP9K/2NWSpsUGiuo2vst06Cb2vJ//AF2WP/uqRa+zPQnH7TqD77bKj9TWv19fxPKOS0V13/5VaRvh1Oo+WxG/oaia77JQv7vVH/VaaB89vKr+vo8o5aaKuuv+zTWW52NaudgG2sfaGAH61WuJcF1Gm/fWXT3Ilf8AcPSfzrF5s+V2F9ZoooMVmsVmiisVmiiMUUGigKKKzQYoooooooooCiisxQFZVSTA5np1+VOfDXhjUa94tABFPruNhE+vUx+EZrsnhXwVptFBX1XTH3rhd0/yggi0PfLH9K1OdT/xznw/9muq1AV7/wD9OjZAYTdIxkW+n1ir1wTwRorJHlWVvODBuXyXgz0T4OnZj71ftNbs2wditec4ZmBg+3qztrXqdUD6TtkCIQA+WT+ENEVuXnn6PC2o637ltfLKC9y/lVeXpgR+QIA5VAe5qzKgWF5xFtd0cgJUf4ZzUxrkNlpxAX+5Y9fpRc1REBYX2GPzPM/nT9ntv9XojvWihHm3WYn8JEL7RJ5Vus3f4iBGAMA/oKxxC3uDbozORg/IYP51XXu3dNBulzaYxbIjdIz0HKAQevI1rfJn/lZG57gXQ9xjNS7euvbSGcPBkO0SB1WQJH1x8jSzh93zSokQ7BVInrjJJ5/OnR0LqSAAYEMeRGc46/8Aes+WNZKgrr03HzFdT19TFf8Aa5z9DWxfIcHbsgrPPBHXE8/Y1puvGFA9RkysgnuQcGIH5VB12jRC129edA3qJXbEz/DtMzjlBrc71i8YXcY8A6PUyyKitE7rJ2n5lPh69hXOePeBtRppZPvUH8I9QHuv/FdMt+KraWwLFoq+NxubTOZwVgg/SInE5rzd163n3CULZiQDn2Bj6UvErErhhFYNdW474esaqSQLd3/8ijmf51/F8+dc741wW9pW23Bg/C4yrD2P9q49cXlrS2iiisqKKKKAooooCiiiiiiisgUAKuHgfwQ+uIu3Zt6cHLD4rh/gT+7ch7nFY+z/AMHNr7huXARp7Z9Z5bzz8tT/AFPQe5Fdt09pVChUhFACACBjsO1a55+6maj6fSpYVbNm2EVAMAGF9vcxPufat66UsNzF5nAnA+gFei/NVYbjznkP+a1Jr1sqVU7jmSf7dq1bfp15yJd9bkRv2kgCE/zApftNtSu6ST1/5pdqfEjAcoJ5ieVJ9Txh26xWMq+ci1ftShdoyepkT/4qNqdahwDj5/5iqsOIQIGOs1t4bbGou7bl0W1gsznkoA6Dr8qk4L+ZM1PEyp7DpHUVjQcTliGQG28Bhy5ciD0YTzzzI61GPCWa95QdGOZZS5QKACHkIcEHH6xUu1pRaCZDQCdxlVjG05xnGc8q3mOV6140uk/ZvMJdjYK59O+5ZYMNjBV+NSTBIAIB5YmvN7xakEFLl4jAki32k/iYARyI/Kmj3nZfuyqER+Iz+ZHq/StFjUXfM27Q0jqNv9BNW3/CT+Ug1XHtXcQwBbWfiAacZ+Jv7ClF+/cbLuWMYkzj/PrTvxZrWDC2V9KGWEgyxA9H0BmTS0FGUbEUzMrsbcOpYMYwO3OunHx8Md/PykWtOAijeAWYA5khYBJgfn/prXrNJdtMVZTjPLMH4SfpWq/et8lRkE+8t2icR3Fer+pusoycYVckQf4ixmT07Vthv0mqLEKetbdRbFxDbuJuQ9D/AFHb50v05zu5EEhh1BGI9/nV44Qhv2VUbCVA9NyZnaN09iOWJHI9aVY4t4i4A2mO5Ja0eTdR7N/zyNI67bxzRCWUoB/EkcwfxAciPlXKvEXBjpnlZNtvhPb+U1w74z3GpSeiiiubQooooCiiiiim/hfgVzX6hbKYHN26Ig5n+w96U127wRwccN0w3iL94B7s80ESlv8A0j1Ed29q1xz5Vm1a9Bp7GkspaUQiCFUczHU/M5JqJxPisCSefQcx7Ur1msLwFkljz7/IVH0eha8XJMJbBLvI2joBu5Seg5npXe8z7XyyZHq/xUk4H+fSl+s1TAkNM/5/kVYjZtae2HY7RcwjGN5A5sFOQB3aMkVK03Ck0tvc/lg3cK77S4JgjaT2iSYxOTWciWqu/CL5UXCBtOZ3KCM9Qc/pXi5wUbCTdCuCBB5Z+XarCjftt3ajKBI8xmIYAkkLIB9Xf6SYFSL/AIP1LhNly0txbe8wzBixHpt7II28/VMyalyIrreH4UE3VQsAwkEj5ECSOnTrUTScL3XCjvAUEkqpPaBn4ZnrXheK6hboW5JMKNhKgZjaTBgRj5da6H4c0iPpVe7b9RQOxUeYbm17gUyAUyMjaTiDUtiT2S6bh0Btzk3lG0kxs2jErHw+mJDwTQLZV9vpaIDYIZTA2sMTMdI5Vq26s3GOq+5t7mRV82ygIJAKkBgcAcszumQIr0umhrd37sqqqzpI3QwA3AgksCABuk/ijEmprUe9VezuYMz7VBB2ruImRIwADGT71Xdb4rS2NqHddAiYlF5cm/GRn2HvTfxQpay9tNLdW0jjzdRsfc+Y2KPiVeUmP0zVXscPs6gAhWA63BMKMxLEkKJHMCtT2lpet608k5Yk5JySe5JrZa0jEqPOtoS3IsYX+YlA047AxVru+Erep0y3rUM6bvgjy7iqCTvIEo0KVnkSR3qL4c4LptSGt20ZD+8m6pMKEMqZWBzkGfY5rW+mcJzbdWKvdRwvpVrTB1x1mKy95RDIA5kbue4beY5yQe8VZ7HhPSO8PcvWwdrKiWngpIBMjA9xgiZIipr+ELVpP2ixq2Xb6tt22/mLJ+F1X1p/CQVp5QxStVbNkyysi3MgMCSpxjdjpFOvD3HXsESPMt9IzHyYcvkavljRrrLK6fUac2vLAAJmComNrMJERBByKoPG+ApYa6bF2RbYSrTbcAicj8QIIIcADnOednWmYa8cuJdm4sFQgM5idxBUnlujI+R71V+J6Fbloq3qVhHuCDM1NOovhwtzcCFxbbkcRMcm6ZqFZZhuRviEe3+Dp9RV+sLXMdfpGsuUYcuXuOhqNV38YcN8y35ij1Jz9161SK81mVuUUVis1FFZooFFW77NODjUarzbgm1ph5jDuZ9C/wC7+ldG1N17rkAFmaTAyT/wP0qB9nfB2TRW1EK+pY3WLYAtiQhPtALe+4VYrmst6ZXs6VizXAou3jHp7Io/P/BXq/HPHn/a5X3UA3P2UsD6r0fhPpt5Aiep+VbLHDXuDcyBEJBa5uXYgjm8naO8HMkY5VX9bd2mOZn36EiJ/X616vvuuhC25bhkKs7GbMHbJBIzz71qi3eHPCovWDqQ24jcFVlndsbHqPVmHTEGKOK6c6kXZvpNpWF/4UVXKKY3NyUSFx17Us03iy9Y0/7P5YW0TsQtKmZnPYDtGatS+KdNdHlNtvMzA7gECKxaFHqGGBEDBrjfJoh4Pq2s/tITYSECAbNtu4QpA9Z+7kyeZBaYB6VP4RxG7cMhXbkguIhbkB5iKQYkAYbkK28X4m6qpsAKoYlAwhGYZ3gj8UkAE+8wazo+M3B6rYI2+lLYcm3EgkBYycbQQYH1qexWrvBrS6m+LC3UQMwa48qo8yZEEBjk5Pz51efB2qW55iWkKWkUpbYlSYBP1kMXOekGlZ1V6/5oum4tt9xLGfRbDj0qrZViPT8682NctlblzyyLV23Z22be7zGulMoPL5lRs3MOozWaR7uJZtai4Q1ljtJX0m8QSUhyg+Jmgj08oGaYMrXEClCv3JCxvChnYAggyV2wsg8j86XcDuFVeTZRgWa8zbi7N5jbwLoMjau0dc1u1urFpbdywhtFpBHqWQIY7eg3YJPMxRVK8QpqbttF1l1lNtrvO5ztwmwhVOQ0GDnII6in3hO/Ye+ujXTB7GptNLsOir8LGcQREc8g+9SOPcAXVWhe8u2wZVZmRWa8HkjasZ24wOXMUoTw89pBDq6C4jrD3LUuDBYkSAdhe2Tg+o1v6Ze/EHARYv6bRKrXFub0GNihcOBOAzKoIMk4I6mpVzga2NQLmqvC3Yt2pLBlKsDhEewcwI6AyTSXjOue9pr1oQbdxh5nqd7YIJhFNyYMqDIIJiqrr9VqLxW21yTbI8tSx9OR6VLSRnoTSSlp/wAY163rTW9NfuradoNgIEtuB+NFPKWPwgzVXt3baAFCVcsWwCre3qnMjNFi21xJAyG2NJ5mCRjt/emGn01u4WG4IqxkfA52gwGbqehNbkRfuB+OQtn7yFLABUVSSTEFp9uZJqDxfW2W1KXAHvG5sgqEhio9WUBkgYJ9s1U7ltNOSrGQMOXPohY6xMzjHUVnU2vKZWTaSwm2o8ySrAE4+EQZEzkzipi6tHG7T6jOnabCELtB9KHMsTEjJ2x8+lK9Rsa0Vbf59kAhuYKk7WQnsDGaZ+FuKX309yzdjahG2Tt2KeSAjmsgkn2Na9dwBidwguJZBJO6R6lE9Bg/UVUJL4BUGJDDr16H9a5nxfSeTdZOk4+Rrp8ekpyIk7TzHIMPp2+tVDxnpYCvGQYMf5/k1z/JPteaqdFFFcmxUnh2kN+7btLzuOqD2LECajVc/sk0Qu8StM2RZV7pB67FwPzIpPktdavW7dpWQKd2zbbURAVRtCx1wvLpnvSPTjzH8pbyessqAAsTETgfDJ5E9jU6/bvXmDCA5uE7TA9yxJ5ACtmu8UOXOm0mmtXVVNo22zDOIlwsxtB7/FMkxXs6tjmQ8ct2bVtbYS411wSXYMqgofULSgepTOWOPSI51E4fZvPcshFZwDKwFEAY3GPhODk9KdavhvEr9w3NQcMgBb0nahJm2u0jyxAO4DpzrybGvt39lswLdv4rVtSq2+uI2liSueZ+VZ0aePatNRdNob7pQwTJbEyw7ds4+Gk+/wAp7eCACLhDDchRDILqOh5Z71Z7nEl0fDmtK9kXbpb4ArOTkEPIAncApIwAppR4dI+4tttb1+bclm9C2z5jW9p/eOxSYYwKlvoXXX8JuXwLnmqp+79OJZnK7UyfSeY5fKl5tq7kovo00j7u4SNvq23C57ZntyrzxTj1vU6ZUm55i3VuB2VAwKE7Z8sAEnv/AFqPau3HtXXKxuUelJUPDHdI5SZ5kZmuMreHWi3yLewK5uXH3GWXbdWIzyEfTHarDxayrsp2FmURaXfs3SZLkpEAx9aqPB/PRgbVxrltYCtuYemP3YEHPMfT3q72uIWn+8uQCuImdgzzkYJE8uhpVJbfCfJ0txLkFWVi+0AgjMbVAj4jzMljJqs6jXvum/cY7BICgTkDIA9K8h6ameM+P7lhPhDAbVIggTtcGO8AD2M86qmq12NgJJxvccjP4RnPz9+la5Z6HH+JS9ry2Kvb8x19R9ILI6KYiWDC4QDyDkdaZXfEF2+wuG7c8vco1CggIlxTAe1BlSVYSvIg59qpfsM0sqxtHWeQ6+9TeBa0izetlQTvnlgyuQY7bR+dW+ok9rvZ0lrR6a/c27gylkuAAPcO4FfQQV9B7gzLfKqJxPhe+2t61cVUljBBDK6lW2gxmZBHamFrxBc0umQEs2+6SEcsyqiAiVE4lm6dqm+H9WNPpy50vm6W7+8C+sAxtLAk+lgvSIx7U5+NKq1jSWzbJa4dzEM6SECk4kQCTtnHQg86gXT5hbZhASFUtkhSfUe56/WBTPi1y3qLjPpE26b4AZhQSBgkmVnsSeU5rRxDhy6XySQGN62LgPqJBJj1QQD3iCOdb1BprjWyssSwAieakmSBE7h2E1O1F43g3lWoNtT5m3CowwzrByAIgHkMcgKVeZ+IDEgHqJ6fMT15yanjiLWwjWh5dyHAKSGK7uZjrBgzMj6UoaapEsovlOxcuVJbzBuUKCpIOZknMRAAFOfDWqLXUDEkke8bdgkc8gNPKDn2qn37OoukPc3FhsG8j1LI9APU+lcTVj8HcTS3dKvzKlZ6jJMRGDk0G7xLw6LpvIYkSx7EblmPfAP5daqPHLAuWnX2/pV41+rt3VNrcBuHMyDIMZJ5AYqpau2UlTkDMiPUJg8sdKz1PQ5fRW/X2ttx17E1org6CKvv2TCLmpuDmtoKP9bZ/pVDrof2VWgbWrY9BbEj/qNb/FP/ALidfCzJdYs0ZBwSJBjBI3dvzq2cHZbeqt7NoAAFwwRKkMRz/mHKAQAMxiqvrENtJiMAgz8Ugco9v71s4dx3ZF3yxuUncwiAB5e1mUsIUZmOZEiJr1/kjnFs8Tcbs29y3bRueWxDNaMXQdsgSCsAbtpO6fbOOdcQ8T3XFy3YHk2Xkm2HdpkrLFy0zCxA9MFsSZpxxHa+tZFuTa1BRluloDF1WehXmsCeWM071+s4Vo0Nq3ZW6wkMtsAXdwBl2dsEHGfykYHHMaczuB22iJIwsCm+k4desuNRslLbD4lKs+4EBoMxMx050y0nF0u3RatW7VsOVBN5lLbQRuAYQvIYX2q+W9dpm8wtqFtKDtA2kLgRksIbHQY5VbiRVSHssbYtj4BMjbIbIds8x9Bit2n1vS0pUA8id2CcSTEn3jrUzVcT0N1zb07b3fBgkqAnLahEkk9Bg7elKhp2V3Q4NvmDOe0COvQGvN3s+Ho4ym/Dr1sST6bhZjglMnruQcj/AAnl0NIuIa4Ddb2tl2JIaecQoxyEdSSe4pk+jmIMKSFLRhS2BPsT1rxrvCF9SzG5ZuAAlAXKM4AMnqMEHE5rM6tidTFb0tsXGhmhcnJAmOg9zWq8SGkACDA59ORM9a9XLgUrtzbYKSJ9W7IaT7kEwMAFazcSVLAQJH6/967cRyqLxjiFy6qhmJgQfoZUTOYk9BXjhl37s9ImffPM1F1QPUVGsEndDhAFJMmAT2+da6nkkuNviHWsXQEkNaRVA6KB6szMmTUHTatlH3Vx7RkEgOQrHuByn9KzavC228gOwyAyhl+ea3XLi3M29NaDknK7wOm0BJ2ggdeszmtSZESDxltQXS6wBulTcMKBcKD0n0gAH3AnmanLpX+6tNFxHxaaRkH4CHmBA5yOWDypYLWmP76zf0pIlXtOLyT3a04Vox+B8dqk6LWFGRbbJqEZwCCjbipMGFaCpyYPcCggJtI6rcRVESSHYTLe09hyip1/cUtXGEAi4g6fA0kDGZLn8qkcf0F3SvdS9bHoaEJ9JdRO1wR8QIFZ0+k8xLIkbCjXN5U70ZSVuLziEhT0mVNXURDduAD1kkkEAzhh1M0x18h1MHcVV7mc7oyZHXnyxSPVp5bMN2/OTGCeZ+fSmdrh4uXdiejccrukqCJGT8Q/79qo3/tfnuTA3dsgEAZPzP61LFxTZKiCQ3xdSCPhBnlOfnUXimgt2rpSxc3lfSROZ25kkCOXISM1480wXAADAHaJ9JHxD5HmKlgoPH1i83vml1OfFX74fKk1eZ1gro32S3vu9andbR//AKNc5q9fZNeHn37cxvtEj5oQf71v8X/cS/Cyaws3xMCF6E8h8hy6fnXrh+gtOR5l3YCJE53MAZG6DtTOZE/lU7VcIuEbgjssZCjIUzJnsCI/KvQ4PctlgyrtKK56DbALQxwPijPUGvZ1XOFvFuHp5iraS8ttj90jdQVG4729I3NEE98xUTW8OvW5ECF5nI7RuxKxOYkdRPRtf1SWLzErvS5bAKghm2N6V9c7Q2D35/lYPDlvT6o+XeJF5i7qrgi4y45K3pbEenBgSJzXO3Fc81nBL6AsbMqDBa2RcSewZcVD2MoODHUGenseddp4t4P0blbouPbB2qxBubWbcApMH0sCRg0ju+EbF7C6kbipJZkZiBJg7S4KmRy2/KseUq4oHDdQgu2yFuDawMhl3yORUxzHuMxXVNPxW1rFLqoLEBXNwKjiBIBBba4PcHFc21nC9Kj3Lb6woyAbd2mvesnmpUSwjGadaTTaCNy61EcQu5gyq4xIe06yB2dZjrWe+di8XFivaL4L2nBuopHn2gZIgDdE/EpMjIn516vubieUjrbQoXRXWdhVtotoT0xGCZ7A4qyaexctbbhsi4AoJuWipOR6sNAuKQBBGYjE17e0msQHSXLZUHKvb3ESP4XhkMZzziuMmOnXWuTanTWi1wLNuLjBNxldsEwSPxSQJ5YzWdNrn05a29tTuA3K4PIGQQQf1q5arwffssjNaTUAKVhBAB9W2UY4WfxAky2R1pNofDF/VqEZLlo2htCvb2hNz4G7/wBQfGQuIEZrtzmOVil6xmE+4kT2PI1Ha4zoEggkEGOox06nlH1q4cQ8Faw3EtJb3Qrqpnap8tpPq5CdxiecVHs+D9Va1OzbaYlQ0Nc2xEnadrZb0nkSIGSK1sTFPOnvOD0UZMwoAHUkxj8682NM7AsLtoBeY81VeO+xhP1E/Stmr07eY6j1Q0MTBCkkxBkj6zWy1wpyEL23VHkqyKlzcFneYDdImrojL5gQNvVknC7g2R028x9YB717s3gQEuCUJncoi6n8y5EkfwkgGOlMG4TqACRahRJZzsHpABlkDEwFIMiY71ru8MZ5NryiRnaLySAchgbhAbHSZ9qbBbLXH01jWNPxEKSEOzVD4LqlRtZlOQ2OnIg1F1BucPvNprxY6e+WK3AsgiIVxukEH258/lWtJqEKG3dXcjZbrtbP3idjByvI/WrLwLWC+q8K1LG5Zu//AG98fHZYZSZ/CPhK8xyrN9BVxrhBtpauSp3llPNs81fkAQw/pUXRawW1wgLLdDszR0kKojMHM1jXDU2r4011vXp28tAQIUdf9JwRWrTCLOoAnfuTd8MbAxBOczuYcuQma3Eb1vC9ddmUIHkk9FgglhmYAnFSrpLS0YMRAxiAD+XX3qFo7iEQy4RHlhzLsRsJ7jEfWmVpQEIgxHfliRSoonipvvvkKTUy8QvN9valteWus+GasX2e6sWtfZ3GFuE2z/rED9YquV7sXSjK6mCpDD5gyKS5dV9Ha2+bepVFQltjhJMJvGZkcwQsweU0y1+nXU2bLglRcGQZOJDeWYHpHP1YnaO9Lk19rUaaxqTbYq+w7lAJUgBgY5wNxUx2q227C2rasp+6y3L8PxE+0869PV+Kw44mmD6hyNoQboJcCFBIAQcyx2nly5mKmWPDvnKt4Xr1pgJYkreuBiQVhw4YYgAkn3gV40+lD3mus9tQqte3MnmBTduCABME7QIHvypnpfEWvtsbVnSK8rP3ak3QsiGe2pOzdP4oOemadVIZeHfEWoFx9HfLi+u4C6EYlwuVLW47YwZkgQZqNxzVNfV2Yo+xWZCg/ECoRds9dzMM9K08S1WpZQuu4fftCBt1CIzm2P4XNqTt5GGxIrXxLRjWWGSxdt+Y0m1cBCpqBBD2gT8DoAoC81284JNZlkVV+JX7jYukKsRMTBA6ADPzJ7V70GissWa5LJ0FtraGOuGJpDbsF7gsOwR/M2TckBGB2srfw5x8xV18PZsXGu7bXk3RbuuSBtJMmQOZxtEDJqpBw7id+xcjTHU+WOVp2YlQPYDEEfLpVr4R41XeP2ldlwHYdrQSRyZ15KfYnqO9ReHMLjK1jaVV/wD1ELOSMn0gbVI55MiBUbjXB9zm4y4WfNcqOWQowYEREkzjArNkadW0eqW4CVIaMGCD/StjXQCBBzyxiuJeGOPXrGpS0LlxUYbwpDE7JaO/pwI6ZFdf0iXGb7zkoEN/ETPSMQIyPeudmLKZVTuKeA7N17txbjpcuGWMyhyfSV6irlSnjPFFtqyhhvgnmBH1NTnd9Fcu8ReGXt2b3m2zAB2lD6AVGbrZg7REAmTyiqTpNA9jN0W7QKghjdthT39aE9Ogz0q9ca1toIP2q9bJUhktgsUOQSgUZYmqno9PY1Mrcvqlt29TLaJZYzG44Uew712Yqdw4aZ/VsN4sVCsCVxHrHXcfn0FSOHhrd0O9kG3kNbCeq4uBDDO5QJPeZinuh4cNPc8m0fNWAsgCWDglW5bSRHMRINSxqAty6zot3arpDL6FZgA4N0Y3Hau4Anl0NSrjn3H+DPo7pBQDdu2rIYQWc29vXaUEgx0IMEUuv2CFW/auZDKTkgo2NrZHOcT8quXi7XDVLZWJuBRO3mY2yd0c+WecUl0OmJ0uqR5BTUptnoWWHWJwTCH8qsSnXH9L+3LpeJg7N9s2tRAmGtsRuA6znPYCap2iuhXYNu23JBVYz1Se+efzrpHgu0Dor6XDIuMwYEEBXFsK4jpkA47jvVB4hoduARvCI5IMg7RBIPuMx0g1qJWdFpBcbcVhSrMVWeW7HuBIP6d6lcSbywVEy3L2mJ/pULTPtJgmAuJwY6Y+ZrT4h1m0FuoX9TNOvUIpHEr2+67DlOPpio1AoryuooFZrFB1n7NeNs2hNhSwfT3gw289jmRyyQHmQOcxXX/C3Exq7ThjJUlWwQDj3yDzxXzH4N4z+yalHY/dv6Ln/S3X6HNfQvg+ybV27BO24ocGZBYMVme+0qflXo5zrj/YxfVVHi/hwWgH1DFUXzGflJ+8hFXEAtu+LoAanNxZzat29H9xZtqS3lyELSswcNc6gsRJJJxTzx3aS6LTXS3kqw3bcT6vxfpHTnUXj9q1YNsAMEKkWxiAQw9MgcvUI9qvzlEXQeI9XZX0+W8ZI2BQRuiAykRE/i9+1PtljittigWxqBIJhWVi2Cjr+MEDI5+9J/J2ISZ3+pQSfT6hBDA8xkR2MGKUu7W1uLZgG2VY3RtDptmACcHn1nv0rN51dePF3gi7fuG5bVVvKJvKWPrCgReBM7pAz7iqwfM8pUt2zce9ebUbVDlSFJVi79FUkEzykV2zh2qOotafVMALiSl0L2Ih49pCmqjo+Gk3tXpbbPb8yXLDb+6cGbYBx6iCBAxmpLqWNvhngOo0u5bbL5hBDCCA5iRcz+EyVk+1W7SLp9daVGC3EtnbctuFaLigellypIme1QLOrVQi2wZf4QCS0DIkzgjII6xyqdoRZR7jBjce40uS0+raABAgCFCjlMAVOpWkrQeG9LYuNeSyouO24nsQCBA5LAMYFM7t0Lzk/IE1XTrPMLW7epNvymKt6Qx5TG4np70o4rorl9Srakkd7beUSeslW3AfLvUnH9NN+L+KLalrVtvvQOW38R5CThT7GkV3iKX7lpdVbvLeQ/Bsm0xMqNx+ZETE0i4rwpHCAF9iDLh2uMd+4Em85lhACwZj0xHOtWv4NcELY9MET8IRUBBJ3SS8ELO4xExmtSYzpf4t4bpbd5sAiQx2bQvNpXaoicICZxPvS3h9oggLuLCYXEAKZxMjAyZmIqfxTQ7D6C5LCDvhmmGJafgVQsDGOU1Guaprenum1h7a21BmUC6hiPMiMlQrCeRJmKB1x3UXLdu1vBtvsO8SxNy2CTtkEbV5mB0q78L0IVAbJG1EAUSNp3LuJMdSTz/lFcw091NhtLtuuiMWuuLhJAYAWwrHbuic5Jz1q7cP4va0j29OrOsIuHSE2T6WnvtP6Zqw1p1XhjVapm/aHSzaJhtoBvMn8IYYQE5nnArzf4ILFm5YQg2kJZ+rb2IIBIyRt2mflypJxvxNefzfJuMr2rjqACCptxKP3kzhs1Z/D+rVrVsbgxKbtykEGckN/NnM9qsGjhlsJbRhIgFT7tJ3MR1blmkHHdH62cgMFTCxzJkH9CsdoNWziN9ERoAEch0/znmqjqOOqStthBII9p9usT/etIqdmfLZDE2mHT1AE5z2/wCKrXijVTCdzn5DlVq43dVHcjBcr9YE/wBYrnnENR5lwt0nHyrl30vM9oworFZrk2zWKzWKAFdm+yfxR5lrybh+8sgD3e1+E+5T4flt7VxmpnCeJXNLdS9aMOhkTyPcEdQa3z141LNfS/E9SFsgFSx3H+EyO/6KaU/aKT5Fm5JKpdG4ATh1HqnsIj6jtS/hetXXafztOZBlvKLGbVwD1JHWRkVP4Lx5dVZaxqLclV8sgGGdCCOXMGMYPMV6M+4wc2NLZ12mR0+MAQRMry3Kc55cvfnSC5owCiX7JJYkDLKS4EpLAjngdiab+H9OtvadPekj4UIULcVeattA23AJzAkit3iIpqbDjccxtIgNbYMJJnIKkzHUTWftpZeG3ENpTb7CcAZPMkRgzSO823U3XZCwAhSAPSIz06nvSHw14r2Eebt33f3mwkwynapAPVgOU9KftqrOoBMn71IVwW8tlJkEiZB98xUkymlfGLeot2fN0rDc0iWgFWbkyE9QT8J5kmseHOOXLitZvaZrN+yo8xWAh5wbisOYJB55z2qdxDSXiNjJbv2j7wzY5wBBPvWOBcN1ARUZ91pPhLk+cAeVtnGHgYk570G25pCSEVnm7JKkz6YyTOI9jzqBxLSrpF3tcIS2w3FU3tLCFUMRKD/OVM9df/ZgNtwI9wEnmxkQAAScRyxn86QaTSX9RaZDegO53F1I3YhRbQjCycsSTIqjZpeOC/buEoti0ORulTugHoQQq4556xS/VEW1OpuXbnqMJFwyxC4IgbdgLAEkcjHysX/wtLR3bZYW/KRio2okzJUfvDI6/wDalg4PfvOrW9TdRZ3G84VnMjFu2igIgH0j3NRFfThVy+igOWBALoAYIBJDtInBACqIJmTgVMRNKpu27xvsHQKtvYu9JYdVXaSGE7uhz3l5e1P7IvkaZWvXAAWa4WLsTzZmWBOOWBmIpfrEZCbqacpe2SxaXWTnlu3En39InlUxVe1Ohawqsqqou5tW842zBheXPkTzMxSy9rLcsG8xlG7YxG9wCSNuSDBiY6TVg1V17rBnViwVU2gLtBzPq5jn0z+VQuG+EVuOWus7jsW6nux5ifatYyqGmtNcceXbLSSCCZBJPIERtAEDn79atXCLZ05Ms4B/HyuWzOEacXF6T7cxNWXT8I0ygKiW4BiYY/rABHyEUu4rYAH3amQTI/DtyMKccoxyxVwQuPcRYKAGkTmAJJ5AHnt5z70htOWYFus+rvjl/WpF2wSSoMY+E8h0gdYAEz86hcZ1iWLW72he5PU/X+1S/Ar3iziMsVB/zrVYr3ful2LHma8V57dbgoooiorNYrNYmgKKKKB74S8S3OH3t6yUaN6TzAOCOzDoa7LprOk12zVWm2M3qBG023I+IEGCp7rINfPs0+8KeJ7ugclfXaYjfbJw0cmH8LDuK6/j/J4+qzY7Nc4TqbTG9pdSrwQ4S4PVgGVV87geUHOefWn5s+ft1NsbGdQXtsCN4MQ+PhYdx/akvh7jtrWoLlkys9wHtmMhl6fMGDNWjSuVAB5d8D/TH9q73+sqynh62+oF2CHJ9SEgDcpBW6pAiRHI4M8xTrR+HGs2wqXSOe5SFIhjJ2hpAaZwDtM9KeAq3vWTB7j+lYtV40g8uQu0KOeGXMZPPH6VttapIwQfYTJPU1GvyVO4kx2x+lYsrKqba7REkHDe0jP6ms4qJxHw3p9XD3N24GQQxEHHTkeXWmy6VQQzDKiB2j/O3evVguR6wFJHec9BWLdojm3XpM/L5U0ZcKBJHcwf0pdftXLh+6cW1AgeknJ6/lOaYfsycis5nMtmZGT/AEra1z/xU0INTwx7Vltt3Ycs7BRJIHpPPIBzn8qrmj4GTdW+t+67A7mliQzDJ3EiByIjlmr7ceOdKeIaUOTcUi2zAKzAAuyAztBPKeRNalQqu2ke4pFmZBbHJWaAenKJrVeBEDypBxERHckd6YWoSQJ7STJqPq75AZt0ACeRO36DJPtWwovBgRIOCYjMTWjVaj3/AKVov6665b7vYAcG5I3fJVyPrSXi/E1tqWdgAO39B3q30Di/ELdkFiRMZPWuY8a4o2ofcfhHwivfG+LnUNgQg5Dqfc0rrz9961IKIorNc1YrNFFBiis1igKKKKAorFZoJvCeK3tLcFyy5Vhz7MOxH4h7V1jw99oVjVqLV+LF7G0t+6ZhyhvwH/qx71xqs1vnu8pY+lOHcbeQl9dtzlMHY/bIwDTuzf3ZzPaTFfN/AvF2p0kKG32xyR5gf9J5r/Sul8C+07TXYW8TaY9Xyvz3L/cV2nfPTNldMuPgEHI6dx1FbeH3VFsBeQx745g0i0vFEurvtOHU9VIdfzWtlnUwZ/Uf5yrV5TViF+vP7RFKRrB3/KvP7eveaniumj6qtX7RSy5rRWh9T7xScmmT6jvUW/eJ5Uuva9QP/NL7/E8GMDr0rXihs90DPM0o13EwMA1VeM+OLFsbVubz2TP6jH61ROK+LL96Qh8tT2+L8+n0rPXfMXFu8ReKktSoO5v4Zk57n8PeuecT4lc1DbnPyHQVDJomuHXd6akFFArNYVgUVmigKKKKDFFZooMUVmsUBRRRQFFFFAVmaxRQb9JrLllt1q49tu6MVP6VZNH9oOvt87i3P+tQT+Yg1VKKs6s+KmOh2ftSu/j06H3V2H6RU239qiRmxc/3A/1rl9Fb/b1/TI6g/wBqVvpYf/ctQNT9pjH4NP8A7nP9hXPprNP29GRaNb471dyduxB7CSPzx+lIdbxK9f8A3l1n9iTH5chUWsVi9W/NMFFFFRRRQKDQFFFZoCsTWaKDFZoooCsUUUAKDWaKDFFFFBkVis0UHmsiiigxWTRRQArNFFBiiiigKyKKKDFFFFACgUUUAKKKKDNFFFAViiig/9k=" },
                new SearchObject() { Name = "Stepan Bandera", Description = "Stepan Andriyovych Bandera (Ukrainian: Степан Андрійович Бандера, Polish: Stepan Andrijowycz Bandera; 1 January 1909 – 15 October 1959) was a head of a militant wing of the Ukrainian independence movement,[1][2] and a leader of the terrorist activity of Ukrainian nationalists.[1]", PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/SBandera-colour.jpg/220px-SBandera-colour.jpg" },
            };

            ViewBag.Name = Name;

            return View(searchObjects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}