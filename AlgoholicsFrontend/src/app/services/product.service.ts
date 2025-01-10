import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  SERVER_URL = environment.SERVER_URL;
  constructor(private http: HttpClient) { }

  /* returneaza toate produsele din backend */
  getAllProducts(numberOfResults = 10) {
    return this.http.get(this.SERVER_URL+'/products', {
      params: {
        limit: numberOfResults.toString()
      }
    });
  }

  products = [
    {
      id: 1, name: 'MACBOOK PRO RETINA 13 INCH', description: ['The MacBook Pro \"Core i5\" 2.6 13 - Inch(Mid - 2014 Retina Display) features a 22 nm \"Haswell\" 2.6 GHz Intel \"Core i5\" processor(4278U), with dual independent processor \"cores\" on a single silicon chip, a 3 MB shared level 3 cache, 8 GB of onboard 1600 MHz DDR3L SDRAM(which could be upgraded to 16 GB at the time of purchase, but cannot be upgraded later), 128 GB or 256 GB of PCIe - based flash storage, and an integrated Intel Iris 5100 graphics processor that shares memory with the system. It also has an integrated 720p FaceTime HD webcam and a high - resolution LED - backlit 13.3\" widescreen 2560x1600 (227 ppi) \"Retina\" display in a case that weighs just less than 3.5 pounds (1.57 kg). It does not have an internal optical drive.',
        'Connectivity includes 802.11ac Wi - Fi, Bluetooth 4.0, two USB 3.0 ports, two \"Thunderbolt 2\" ports, an HDMI port, an audio in/out port, and an SDXC card slot.',
        'In addition, this model has a backlit keyboard, a \"no button\" glass \"inertial\" multi - touch trackpad, a \"MagSafe 2\" power adapter, and an internal, sealed battery that provides an Apple estimated 9 hours of battery life.'], image: '/assets/img/product01.png', price: 980.00 },

    {
      id: 2, name: 'CASTI SUPERLUX HD681', description: ['Key Features:',
        'Semi - open, Circumaural(full size), Dynamic, Self - adjusting headband, Peak SPL: 98 dB, Impedance: 32 Ohm, Frequency Range: 10 – 30000 Hz, Maximum Power: 300 mW, 2, 5m Cable with 3, 5 mm Stereo mini- jack, Weight(including cable): 278 g, Weight(excluding cable): 230 g, Including 6, 3 mm mini - jack adapter and a bag, 50mm Neodymium Drivers Circumaural'], image: '/assets/img/product02.png', price: 145.00},

    {
      id: 3, name: 'MACBOOK PRO 15.4 INCH', description: ['Specifications: ',
        'Apple MacBook Pro 15-inch Retina display 2.5GHz Quad Core Intel, Core i7, Turbo Boost up to 3.7GHz, 16GB 1600MHz memory, 512GB PCIe - based flash storage, Intel Iris Pro Graphics, AMD Radeon R9 M370X with 2GB GDDR5 memory, Built-in battery(9 hours), Force Touch trackpad, Apple Mouse'], image: '/assets/img/product03.png', price: 2305.00},

    {
      id: 4, name: 'TASTATURA GAMING NATEC', description: ['GENESIS RHOD 300 RGB.Keyboard form factor: Full - size(100 %), Device interface: USB, Keyboard key switch: Mechanical, Keyboard layout: QWERTY, Keyboard number of keys: 104. Cable length: 1.75 m.Recommended usage: Gaming.Product colour: Black'], image: '/assets/img/product14.jpg', price: 275.00
    },

    {
      id: 5, name: 'SONY MDR-CD 1700', description: ['Key Features: ',
       'Newly developed materials guarantee outstanding sound quality in these high - end headphones. Soft, self - adjusting headband and comfortable velvet ear pads, 50 mm bio - cellulose Vectran diaphragm, ABS resin housing minimizes self - resonance, Neodymium magnet for powerful, accurate bass.',
        'Rated frequency range: 5 - 30,000 Hz, Nominal impedance: 32 Ohm, Sensitivity: 106 dB / mW, Rated power handling: 1000 mW, Cable length: 3.5 m, Weight(without cable): 325 g, Stereo jack plug: 3.5 mm gold - plated / 6.3 mm(with gold - plated adapter), Cable routing on one side, closed design, Special features: 6 star model'], image: '/assets/img/product05.png', price: 322.00
    },

    {
      id: 6, name: 'SAMSUNG GALAXY EDGE S7', description: ['This update to Samsung\'s flagship curved - screen phone has a larger battery, memory card slot, upgraded 12 - megapixel camera, always - on display, and curved - edge glass on the front and back.It\'s also larger, replacing both the edge and edge+ from 2015. Other features include a quad-HD display, 4 GB of RAM, front camera, water resistance, heart rate monitor, and fingerprint sensor. It also supports Samsung Pay - via both NFC and magnetic card emulation - and universal wireless charging.'], image: '/assets/img/product07.png', price: 1349.00
    },

    { id: 7, name: 'Canon EOS R100', description: ["Dual Pixel CMOS AF system. 24.1 MP resolution. DIGIC 8 processor. Wi-Fi, Bluetooth. The EOS R100 camera packs powerful features into a compact body and, in combination with or varied lens selection, delivers excellent image and video quality. This mirrorless camera features the DIGIC 8 image processor for more flexible and efficient operation and operation, complemented by a 24.1MP Dual Pixel CMOS AF sensor that captures every detail. Canon's camera is the ideal companion for travel and everyday use, and many sales days are suitable for autofocus with the Dual Pixel CMOS AF system.Get true depth of field thanks to a sensor that's 4 times larger than the one on a top smartphone. Automatic image transfer."], image: '/assets/img/product094.png', price: 2190.00 },

    {
      id: 8, name: 'ASUS X200MA', description: ['Asus X200MA is a DOS laptop with a 11.06-inch display that has a resolution of 1366x768 pixels. It is powered by a Celeron Dual Core processor and it comes with 2GB of RAM. The Asus X200MA packs 500GB of HDD storage.',
        'Graphics are powered by Intel Integrated Graphics.Connectivity options include Wi - Fi 802.11 b / g / n, Bluetooth, Ethernet and it comes with 2 USB ports(2 x USB 2.0, 1 x USB 3.0), HDMI Port, Multi Card Slot, VGA Port, Mic In, RJ45(LAN) ports.'], image: '/assets/img/product08.png', price: 830.00
    },

    {
      id: 9, name: 'APPLE IPHONE 13', description: ['The iPhone 13 brings a few subtle updates compared to the iPhone 12, but you might find that the previous year\'s model offers better value.This phone has a bright, vibrant 6.1 - inch OLED screen, but with only a 60Hz refresh rate and an annoying notch.The A15 Bionic SoC provides more than enough power for gaming and heavy apps. The cameras are versatile and deliver great quality for stills as well as video, plus you get the same Cinematic Mode and Photographic Styles features as on the more expensive iPhone 13 Pro.Battery life is good, but not great.iOS 15 keeps everything running smoothly.You can choose between 128GB, 256GB and 512GB of storage.The iPhone 13 mini is equivalent in terms of features and performance.'], image: '/assets/img/product10.jpg', price: 2599.00
    },

    {
      id: 10, name: 'SONY CYBER-SHOT', description: ['The Cyber-shot W570 digital camera features a 16.1-megapixel CCD image sensor, 2.7" LCD and a 5x optical zoom lens starting at 25mm. It can record 720p HD videos and comes with features such as Optical SteadyShot image stabilization, Intelligent Auto (iAuto) mode and Sweep Panorama. For those who want step-by-step instructions to shoot better pictures there is an in-camera guide along with functions such as Anti-blink and in-camera editing tools for better everyday photography.'], image: '/assets/img/product12.png', price: 2879.00
    },

    {
      id: 11, name: 'MOUSE GAMING LOGITECH G502 HERO', description: ['Key Features: ',
        '11 Programmable Buttons, Five 3.6g Optional Weights, Logitech HERO™ 25K Sensor, Customizable Lightsync RGB, On - Board Memory for 5 Profiles, Ergonomic design'], image: '/assets/img/product13.jpg', ptice: 325.00
    },

    {
      id: 12, name: 'GALAXY A15 LTE', description: ['Specifications: ',
        'Dimensions: 160.1 x 76.8 x 8.4 mm, Weight: 200 g, Chipset: Mediatek Helio G99(6nm), Built -in memory: 128GB 4GB RAM, Screen: Super AMOLED 6.5 inches, Battery: 5000 mAh, Rear camera: Triple, 50MP, Front camera: Single, 13MP'], image: '/assets/img/product11.jpg', price: 649.00 },

  ];

  getProductById(id:number){
    return this.products.find(product => product.id === id);
  }
}
