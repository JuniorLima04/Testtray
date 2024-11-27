<template>
 <div class="container">
    <div class="header-container d-flex align-items-center justify-content-between">
        <div class="logo">
            <h1 class="text-light">
                <a href="/">
                    <span>SneakerWorld</span>
                </a>
            </h1>
        </div>

      <nav id="navbar" class="navbar d-flex align-items-center justify-content-end" style="background: rgba(0, 0, 0, 0.85); padding: 12px 25px; border-radius: 50px; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);">
  <ul class="d-flex list-unstyled mb-0">
    <li class="mx-3">
      <a class="getstarted scrollto" href="/" style="color: white; padding: 12px 25px; border: 2px solid #ff4500; border-radius: 50px; background-color: transparent; font-weight: 600; text-transform: uppercase; transition: all 0.3s ease; position: relative; overflow: hidden;">
        <span style="position: relative; z-index: 1;">Home</span>
        <span class="hover-bg" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; background: #ff4500; transform: translateX(-100%); transition: transform 0.3s ease;"></span>
      </a>
    </li>
    <li class="mx-3">
      <a class="getstarted scrollto" href="/cad" style="color: white; padding: 12px 25px; border: 2px solid #ff4500; border-radius: 50px; background-color: transparent; font-weight: 600; text-transform: uppercase; transition: all 0.3s ease; position: relative; overflow: hidden;">
        <span style="position: relative; z-index: 1;">Cadastre-se</span>
        <span class="hover-bg" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; background: #ff4500; transform: translateX(-100%); transition: transform 0.3s ease;"></span>
      </a>
    </li>
    <li class="mx-3">
      <a class="getstarted scrollto" href="/com" style="color: white; padding: 12px 25px; border: 2px solid #ff4500; border-radius: 50px; background-color: transparent; font-weight: 600; text-transform: uppercase; transition: all 0.3s ease; position: relative; overflow: hidden;">
        <span style="position: relative; z-index: 1;">Compra</span>
        <span class="hover-bg" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; background: #ff4500; transform: translateX(-100%); transition: transform 0.3s ease;"></span>
      </a>
    </li>
  </ul>
  <i class="bi bi-list mobile-nav-toggle" style="font-size: 1.5rem; color: white; cursor: pointer;"></i>
</nav>

<div class="form-group brand-filter-container">
  <label for="brandFilter" class="brand-filter-label">
    <i class="fas fa-filter"></i> Filtrar por marca:
  </label>
  <div class="custom-select-wrapper">
    <select v-model="selectedBrand" class="custom-select" id="brandFilter">
      <option value="" class="default-option">Todas as marcas</option>
      <option value="Nike">Nike</option>
      <option value="Adidas">Adidas</option>
      <option value="Puma">Puma</option>
      <option value="Lacoste">Lacoste</option>
      <option value="NB">New Balance</option>
      <option value="Vans">Vans</option>
    </select>
  </div>
</div>
</div>


<div class="row">
  <div class="col-sm-4" v-for="(item, index) in products.filter(item => item.brand == selectedBrand || selectedBrand == '')" v-bind:key="index">
    <img :src="item.image" class="card-img-top" alt="...">
    <div class="card-body">
      <h5 class="card-title">{{ item.title }}</h5>
      <p class="card-text">{{ item.description }}</p>
      <ul class="list-group list-group-flush">
        <li class="list-group-item">Preço: R$ {{ item.price }}</li>
        <li class="list-group-item">Ano: {{ item.year }}</li>
      </ul>
      <div class="buy-section">
        <button type="button"  :id="getBtnId(index)" class="btn btn-primary buy-btn" data-bs-toggle="modal" data-bs-target="#escolhaEcommerceModal">Comprar</button>
        <button type="button" id="cart-btn01" class="btn btn-secondary" @click="addToCart(item)">Carrinho</button>
      </div>
    </div>
  </div>
</div>


    <div id="escolhaEcommerceModal" class="modal fade" tabindex="-1" aria-labelledby="escolhaEcommerceModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <form @submit.prevent="finalizePurchase">
        <div class="modal-header">
          <h4 class="modal-title">Preencha seu formulário</h4>
          <button type="button" id="btnFinaliza" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="form-group">
            <label for="email">Email:</label>
            <input type="email" class="form-control" id="email" v-model="formData.email" placeholder="Digite o seu email" required>
            <span class="text-danger">{{ emailError }}</span>
          </div>
          <div class="form-group">
            <label for="endereco">Endereço:</label>
            <input type="text" class="form-control" id="endereco" v-model="formData.endereco" placeholder="Digite o seu endereço" required>
            <span class="text-danger">{{ enderecoError }}</span>
          </div>
          <div class="form-group">
            <label for="cidade">Cidade:</label>
            <input type="text" class="form-control" id="cidade" v-model="formData.cidade" placeholder="Ex: Marília" required>
            <span class="text-danger">{{ cidadeError }}</span>
          </div>
          <div class="form-group">
            <label for="estado">Estado:</label>
            <input type="text" class="form-control" id="estado" v-model="formData.estado" placeholder="São Paulo" required>
            <span class="text-danger">{{ estadoError }}</span>
          </div>
          <div class="form-group">
            <label for="complemento">Complemento:</label>
            <textarea class="form-control" id="complemento" v-model="formData.complemento" rows="3" placeholder="ex: ap 302"></textarea>
            <span class="text-danger">{{ complementoError }}</span>
          </div>
        </div>
        <div class="modal-footer">
          <button @click="showAlert()" type="submit" class="btn btn-primary">Finalizar compra</button>
        </div>
      </form>
    </div>
  </div>
</div>


    <!-- Modal de sucesso -->
    <div class="modal fade" id="purchaseSuccessModal" tabindex="-1" aria-labelledby="purchaseSuccessModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Compra realizada!</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <p>{{ successMessage }}</p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import CompraService from '@/services/CompraService';

const formData = ref({
  email: '',
  endereco: '',
  cidade: '',
  estado: '',
  complemento: ''
});

const router = useRouter()
function showAlert() {
  alert("Vimos que voce nao é cadastrado, cadastre-se e receba 10% de desconto")
}

const selectedBrand = ref('')

if (router.currentRoute.value.query.brand) {
    selectedBrand.value = router.currentRoute.value.query.brand

    useRouter().push({ query: {} });
}

const getBtnId = (i) =>{
    return `btnComprar_${i}`;
  }

const products = [
  {
    'image': 'https://sneakersul.com.br/cdn/shop/files/nike-sb-dunk-low-chunky-dunky-ben-jerry-1.webp?v=1711918710&width=2048',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://artwalk.vtexassets.com/arquivos/ids/514080/IG377-7-100-1.jpg?v=638493991950600000',
    'title': 'Adidas',
    'brand': 'Adidas',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
  },
  {
  'image': 'https://img-br.prvstatic.com/front/get/photo/245346_-_images_-_products_-_FB7065-600_600_-_templ1.jpg',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://keeprunningbrasil.vtexassets.com/arquivos/ids/419685-800-800?v=638230445369170000&width=800&height=800&aspect=true',
    'title': 'NB',
    'brand': 'NB',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://static.fatimaesportes.com.br/public/fatimaesportes/imagens/produtos/tenis-adidas-galaxy-6-feminino-640746d8b05aa.jpg',
    'title': 'Adidas ',
    'brand': 'Adidas',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://static.glami.com.br/img/800x800bt/399051976-tenis-lacoste-masculino-l003-sneakers-wht-nvy-red-branco.jpg',
    'title': 'Lacoste',
    'brand': 'Lacoste',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://imgmarketplace.lojasrenner.com.br/20001/1567/7010702505089/7510705730255/0.jpeg',
    'title': 'Lacoste',
    'brand': 'Lacoste',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://artwalk.vtexassets.com/arquivos/ids/223769/Tenis-Vans-Old-Skool-Masculino-Azul.jpg?v=637261783757800000 ',
    'title': 'Vans',
    'brand': 'Vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://imgcentauro-a.akamaihd.net/1366x1366/98172851.jpg',
    'title': 'Adidas',
    'brand': 'Adidas',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://images.tcdn.com.br/img/img_prod/710537/tenis_puma_masculino_caven_2_0_bdp_branco_preto_3987_1_2402df90af39f8d95df8d8ba31a10b0f.jpg',
    'title': 'Puma',
    'brand': 'Puma',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  },
  {
  'image': 'https://rogerstenis.vteximg.com.br/arquivos/ids/2835290-1000-1000/1000920028_1.jpg?v=638288513141800000',
    'title': 'Vans',
    'brand': 'Vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 1500,
    'year': 2024
    
  }, 
  {
    'image': 'https://cdn.bnws3.com.br/b2online.com.br/image/cache/data/produtos/new-balance/unissex/tenis-new-balance-574-v2-unissex-preto---latex-10446-24-03-06-1200x1200.jpg',
    'title': 'Tenis NB ',
    'brand': 'NB',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 400,
    'year': 2023
  },
  {
    'image': 'https://newbrasil.vtexassets.com/arquivos/ids/158015-800-auto?v=638285917961830000&width=800&height=auto&aspect=true',
    'title': 'NB 237',
    'brand': 'NB',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://images.tcdn.com.br/img/img_prod/935724/tenis_puma_preto_branco_prata_masculino_x_ray_2_11683_1_a9afd1cebbd2bc8b46b08c143c430495.jpg',
    'title': 'Puma x-ray',
    'brand': 'Puma',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://images.puma.com/image/upload/f_auto,q_auto,b_rgb:fafafa/global/396330/05/fnd/BRA/w/1000/h/1000/fmt/png',
    'title': 'Puma caven 2.0',
    'brand': 'Puma',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 300,
    'year': 2023
  },
  {
    'image': 'https://espacocon.fbitsstatic.net/img/p/tenis-puma-trinity-preto-branco-verde-38928905-152450/365249-2.jpg?w=1000&h=1000&v=no-value',
    'title': 'Puma trinity',
    'brand': 'Puma',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://rogerstenis.vteximg.com.br/arquivos/ids/2843042-1000-1000/1000922993_1.jpg?v=638349124534600000',
    'title': 'Vans ultrarange',
    'brand': 'vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 780,
    'year': 2023
  },
  {
    'image': 'https://images.tcdn.com.br/img/img_prod/921115/tenis_vans_authentic_black_9785_1_0a84ea67fb5af835f180f0258d8d655d_20220707171402.jpg',
    'title': 'Vans authentic black',
    'brand': 'Vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 550,
    'year': 2022
  },                //daqui para baixo adiconar tenis
  {
    'image': 'https://artwalk.vtexassets.com/arquivos/ids/480183/DD139-1-103-1.jpg?v=638445807883100000',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://www.copclub.com.br/cdn/shop/products/Nike-Dunk-Low-World-Champ-DR9511-100-4.png?v=1657821528&width=450',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbEwP14H2m7rdcECjD-x2vRIihenluH7kkJQ&s',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://imgnike-a.akamaihd.net/1300x1300/03399952A2.jpg',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQXpWLChrykx1vsNXPqqXNOKg-vCZ8uwkBGlw&s',
    'title': 'Adidas',
    'brand': 'Adidas',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://imgcentauro-a.akamaihd.net/1366x1366/98140431.jpg',
    'title': 'Adidas',
    'brand': 'Adidas',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://assets.adidas.com/images/w_600,f_auto,q_auto/e8f76f593c804f90bdcefd57033aff3e_9366/Tenis_Handball_Spezial_Verde_IF8913_01_standard.jpg',
    'title': 'Adidas',
    'brand': 'Adidas',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://images.tcdn.com.br/img/img_prod/1220692/tenis_lacoste_audyssor_trail_zip_8600_1_83cc768d5dee041ed8fbd1a750b2b47c.png',
    'title': 'Lacoste',
    'brand': 'Lacoste',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://imgcentauro-a.akamaihd.net/1366x1366/98213142.jpg',
    'title': 'Lacoste',
    'brand': 'Lacoste',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://imgmarketplace.lojasrenner.com.br/20001/1567/700622056/752102040/0.jpeg',
    'title': 'Lacoste',
    'brand': 'Lacoste',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://images.tcdn.com.br/img/img_prod/974601/tenis_lacoste_t_clip_123_preto_branco_creme_5919_1_b91d8b239bb565a74ae4f5b9bf4a3223.png',
    'title': 'Lacoste',
    'brand': 'Lacoste',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://cdn.awsli.com.br/257/257889/produto/60197763/52abeac6fa.jpg',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://cdn.awsli.com.br/1167/1167039/produto/234683791/5-sxtxhafum6.jpg',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://gdlp.com.br/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/f/z/fz1670-001_1.jpg',
    'title': 'Nike Dunk',
    'brand': 'Nike',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://cdn.bnws3.com.br/b2online.com.br/image/cache/data/produtos/vans/calcados-femininos/tenis-vans-ward-plataforma-feminino-verde---branco-11745-24-07-12-1200x1200.jpg',
    'title': 'Vans',
    'brand': 'Vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },                        //adicionar daqui para baixo
  {
    'image': 'https://d1q83jvjv6c875.cloudfront.net/Custom/Content/Products/18/40/184058_tenis-puma-caven-bmw145856_m5_638332265156074191.jpg',
    'title': 'Puma bmw',
    'brand': 'Puma',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://images.tcdn.com.br/img/img_prod/984293/tenis_casual_masculino_puma_smash_v2_367147_1281_1_2454b478ef4a056f76cead64644ec9fa.jpg',
    'title': 'Puma smash',
    'brand': 'Puma',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://imgcentauro-a.akamaihd.net/1366x1366/98170112.jpg',
    'title': 'New Balance',
    'brand': 'NB',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://images.tcdn.com.br/img/img_prod/560775/tenis_new_balance_feminino_574_v2_rosa_claro_wl574gk2_16867_1_26f6dcc7943b088d8aa7d1b8e27b485f.jpg',
    'title': 'New balace feminino',
    'brand': 'NB',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://imgmarketplace.lojasrenner.com.br/20001/4273/7010703634794/7510707172283/0.jpg',
    'title': 'New Balance Green',
    'brand': 'NB',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://backwash.fbitsstatic.net/img/p/tenis-vans-ultrarange-vr3-red-96614/362764.jpg?w=800&h=800&v=no-change&qs=ignore',
    'title': 'Vans',
    'brand': 'Vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
  {
    'image': 'https://mediacdn.wtennis.com.br/catalog/product/cache/2/image/400x400/9df78eab33525d08d6e5fb8d27136e95/v/a/vans_seldan_retro_ag_13_1026834.jpg',
    'title': 'Vans',
    'brand': 'Vans',
    'description': "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
    'price': 900,
    'year': 2023
  },
]

const successMessage = ref('');
const emailError = ref('');
const enderecoError = ref('');
const cidadeError = ref('');
const estadoError = ref('');
const complementoError = ref('');

async function finalizePurchase() {
  // Validar formulário
  if (!validateForm()) {
    return;
  }

  const compraData = {
    Produto: 'Nike Dunk',
    Preco: 900, // Ajustado para número (decimal) conforme necessário
    Email: formData.value.email,
    Cidade: formData.value.cidade,
    Estado: formData.value.estado,
    Complemento: formData.value.complemento // Adicionado complemento
  };

  

  try {
    await CompraService.create(compraData);
    successMessage.value = 'Compra realizada com sucesso!';
    // Resetar o formulário
    clearForm();
    // Abrir o modal de sucesso
    const successModal = new bootstrap.Modal(document.getElementById('purchaseSuccessModal'));
    successModal.show();
  } catch (error) {
    console.error('Erro durante a compra:', error);
    if (error.response && error.response.data && error.response.data.error === "Email não registrado.") {
      emailError.value = 'Email não registrado. Por favor, registre seu email antes de realizar a compra.';
    }
  }
}

function validateForm() {
  let valid = true;
  emailError.value = '';
  enderecoError.value = '';
  cidadeError.value = '';
  estadoError.value = '';
  complementoError.value = '';

  if (!formData.value.email) {
    emailError.value = 'Por favor, informe seu email.';
    valid = false;
  }
  if (!formData.value.endereco) {
    enderecoError.value = 'Por favor, informe seu endereço.';
    valid = false;
  }
  if (!formData.value.cidade) {
    cidadeError.value = 'Por favor, informe sua cidade.';
    valid = false;
  }
  if (!formData.value.estado) {
    estadoError.value = 'Por favor, informe seu estado.';
    valid = false;
  }

  return valid;
}

function clearForm() {
  formData.value.email = '';
  formData.value.endereco = '';
  formData.value.cidade = '';
  formData.value.estado = '';
  formData.value.complemento = '';
}

function addToCart(product) {
  console.log(product)
  router.push({
    name: 'cart',
      params: {
        brand: product.brand
    }
  });
}


</script>


<style scoped>

/* Estilo geral do contêiner */
.container {
  background-color: #f9f9f9;
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  padding: 20px;
  max-width: 1200px;
  margin: 0 auto;
}

/* Container do filtro */
.brand-filter-container {
  margin: 20px 0;
  padding: 15px;
  background-color: #fff; /* Cor de fundo branca para destacar o filtro */
  border-radius: 8px; /* Bordas arredondadas para um visual mais suave */
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); /* Sombra suave para um toque moderno */
  display: flex;
  flex-direction: column;
  align-items: flex-start; /* Alinha o conteúdo ao início do contêiner */
  max-width: 300px; /* Largura máxima ajustada para um layout mais balanceado */
}

/* Rótulo do filtro */
.brand-filter-label {
  font-size: 1rem; /* Tamanho da fonte ajustado para compactação */
  color: #333; /* Cor do texto para melhor legibilidade */
  display: flex;
  align-items: center;
  margin-bottom: 12px; /* Margem para separar o rótulo do select */
  font-weight: 600; /* Peso da fonte para mais ênfase */
}

/* Ícone do filtro */
.brand-filter-label i {
  margin-right: 8px; /* Margem ao redor do ícone para melhor espaçamento */
  color: #ff4500; /* Cor do ícone para destaque */
}

/* Contêiner do select */
.custom-select-wrapper {
  width: 100%;
}

/* Estilo do select */
.custom-select {
  width: 100%;
  padding: 8px 12px; /* Padding ajustado para um controle mais compacto */
  font-size: 0.875rem; /* Tamanho da fonte ajustado */
  border: 1px solid #ced4da; /* Borda leve para um visual limpo */
  border-radius: 5px; /* Bordas arredondadas */
  background-color: #fff; /* Cor de fundo branca para contraste */
  appearance: none; /* Remove o estilo padrão do select */
  cursor: pointer; /* Cursor de ponteiro para interatividade */
  background: #fff url('data:image/svg+xml;charset=utf8,%3Csvg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 10 6"%3E%3Cpath d="M5 6l5-5H0l5 5z" fill="%23999"/%3E%3C/svg%3E') no-repeat right 10px center;
  background-size: 12px; /* Tamanho do ícone de seleção */
  transition: border-color 0.3s ease; /* Transição suave para a cor da borda */
}

/* Estilo do select ao focar */
.custom-select:focus {
  border-color: #ff4500; /* Cor da borda ao focar para um destaque sutil */
  outline: none; /* Remove o contorno padrão */
  box-shadow: 0 0 0 0.2rem rgba(255, 69, 0, 0.25); /* Sombra ao focar para destaque adicional */
}

/* Estilo da opção padrão */
.default-option {
  color: #6c757d; /* Cor de texto para o placeholder */
}

/* Estilo dos botões */
.btn-primary, .btn-secondary {
  padding: 10px 20px;
  border-radius: 50px;
  font-size: 1.2rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.3s, transform 0.3s;
  border: none;
}

.btn-primary {
  background-color: #ff4500;
  color: #fff;
}

.btn-primary:hover {
  background-color: #ff6347;
  transform: translateY(-2px);
}

.btn-secondary {
  background-color: #333;
  color: #ff4500;
  border: 2px solid #ff4500;
}

.btn-secondary:hover {
  background-color: #ff4500;
  color: #fff;
  transform: translateY(-2px);
}

/* Estilo do modal */
.modal-content, .modal-header, .modal-footer {
  background-color: #222;
  color: #fff;
  border-radius: 12px;
}

.modal-header, .modal-footer {
  border-color: #ff4500;
  padding: 15px;
}

.modal-title {
  font-size: 1.5rem;
  color: #ff4500;
}

/* Estilo dos campos de formulário */
.form-control {
  background-color: #333;
  border: 1px solid #ff4500;
  color: #fff;
  padding: 12px;
  border-radius: 8px;
  font-size: 1rem;
  transition: border-color 0.3s, box-shadow 0.3s;
}

.form-control:focus {
  border-color: #ff6347;
  box-shadow: 0 0 5px rgba(255, 99, 71, 0.5);
  outline: none;
}

.text-danger {
  color: #ff4500;
  font-size: 0.875rem;
}

/* Estilo do card */
.card {
  margin-top: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.card-img-top {
  height: 200px;
  object-fit: cover;
}

/* Estilo do cabeçalho */
.header-container, #header {
  background-color: #2c2c2c;
  color: #fff;
  padding: 15px 20px;
  border-bottom: 2px solid #444;
  display: flex;
  align-items: center;
  justify-content: space-between;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
}

.nav-link {
  padding: 10px 20px;
  border-radius: 30px;
  font-weight: 500;
  text-transform: capitalize;
  position: relative;
  transition: background-color 0.3s, color 0.3s;
}

.nav-link:hover {
  background-color: rgba(255, 255, 255, 0.1);
  color: #ff4500;
}

.logo span {
  font-size: 2.5rem;
  font-family: 'Montserrat', sans-serif;
  font-weight: 700;
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
}

.logo a:hover span {
  color: #ff4500;
  transform: scale(1.05);
}

/* Estilo da seção inicial (hero) */
#hero {
  height: 100vh;
  background-color: #000;
  color: #fff;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  position: relative;
  overflow: hidden;
}

#hero img {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
  z-index: -1;
}

#hero .overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
}

#hero h1, #hero h2 {
  font-family: 'Montserrat', sans-serif;
  color: #fff;
  text-shadow: 2px 2px 8px rgba(0, 0, 0, 0.7);
}

#hero h1 {
  font-size: 3.5rem;
  font-weight: 700;
  margin-bottom: 10px;
}

#hero h2 {
  font-size: 2rem;
  font-weight: 300;
  margin-bottom: 30px;
}

#hero .btn-primary {
  font-size: 1.5rem;
  padding: 15px 30px;
  border-radius: 50px;
  text-transform: uppercase;
  transition: transform 0.3s;
}

#hero .btn-primary:hover {
  transform: scale(1.05);
}





</style>
