<template>
  <div class="cart-container">
    <h1>Seu Carrinho</h1>
    <div v-if="cartItems.length > 0">
      <div v-for="item in cartItems" :key="item.id" class="cart-item">
        <img :src="item.image" class="cart-item-img" alt="Imagem do produto">
        <div class="cart-item-info">
          <h5>{{ item.title }}</h5>
          <p><strong>Marca:</strong> {{ item.brand }}</p>
          <p><strong>Preço:</strong> R$ {{ item.price.toFixed(2) }}</p>
          <p><strong>Ano:</strong> {{ item.year }}</p>
          <button @click="removeItem(item.id)" class="remove-btn">Remover</button>
        </div>
      </div>
      <div class="cart-total">
        <h3>Total: R$ {{ cartTotal }}</h3>
      </div>
    </div>
    <div v-else>
      <p>Seu carrinho está vazio.</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      cartItems: JSON.parse(localStorage.getItem('cart')) || []
    };
  },
  mounted() {
    if (this.cartItems.length === 0) {
      const tempItem = {
        id: 1,
        image: 'https://sneakersul.com.br/cdn/shop/files/nike-sb-dunk-low-chunky-dunky-ben-jerry-1.webp?v=1711918710&width=2048',
        title: 'Nike Dunk',
        brand: 'Nike',
        description: "A colaboração inovadora entre Nike e Ben & Jerry's resultou no Nike Dunk Low SB 'Chunky Dunky', inspirado no sabor de sorvete Chunky Monkey.",
        price: 900,
        year: 2023
        
      };
      

      this.cartItems.push(tempItem);
      localStorage.setItem('cart', JSON.stringify(this.cartItems));
    }
    
    console.log(this.$route.params.brand);
  },
  computed: {
    cartTotal() {
      return this.cartItems.reduce((total, item) => total + item.price, 0).toFixed(2);
    }
  },
  methods: {
    removeItem(id) {
      this.cartItems = this.cartItems.filter(item => item.id !== id);
      localStorage.setItem('cart', JSON.stringify(this.cartItems));
    }
  }
};
</script>

<style scoped>
.cart-container {
  padding: 20px;
  background-color: #f5f5f5;
  color: #333;
  max-width: 1200px;
  margin: 0 auto;
}

h1 {
  color: #ff6600;
  font-family: 'Roboto', sans-serif;
  margin-bottom: 30px;
  text-align: center;
  font-size: 2rem;
}

.cart-item {
  display: flex;
  align-items: center;
  margin-bottom: 20px;
  border-radius: 10px;
  overflow: hidden;
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
  background-color: #fff;
  transition: transform 0.3s, box-shadow 0.3s;
}

.cart-item:hover {
  transform: translateY(-5px);
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.25);
}

.cart-item-img {
  width: 150px;
  height: 150px;
  object-fit: cover;
  border-right: 4px solid #ff6600;
}

.cart-item-info {
  padding: 20px;
  flex: 1;
}

.cart-item-info h5 {
  font-size: 1.4rem;
  color: #333;
  font-family: 'Roboto', sans-serif;
  margin-bottom: 10px;
}

.cart-item-info p {
  margin: 5px 0;
  font-size: 1rem;
  color: #666;
  font-family: 'Roboto', sans-serif;
}

.cart-item-info p strong {
  color: #ff6600;
}

.remove-btn {
  margin-top: 10px;
  background-color: #ff6600;
  color: #fff;
  border: none;
  border-radius: 5px;
  padding: 8px 12px;
  font-size: 0.9rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.remove-btn:hover {
  background-color: #e65c00;
}

.cart-total {
  margin-top: 30px;
  padding: 20px;
  background-color: #333;
  color: #fff;
  border-radius: 8px;
  font-size: 1.5rem;
  font-weight: bold;
  text-align: center;
}
</style>


