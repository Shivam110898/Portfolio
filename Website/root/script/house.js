//object oriented jquery approach to the shopping cart
(function($) {
    $.Car = function(element) {
        this.$element = $(element);
        this.init();
    };

    $.Car.prototype = {
        // initializes properties and methods
        init: function() {
            this.cartPrefix = "Transp-"; //prefix string to be prepended to the cart's name in session storage
            this.cartName = this.cartPrefix + "cart";// cart's name in session storage
            this.total = this.cartPrefix + "total"; //total
            this.storage = sessionStorage;//session storage object

            this.$formAddToCart = this.$element.find("form.add-to-cart"); //form for adding items to cart
            this.$formCart = this.$element.find("#shopping-cart"); //shopping cart form
            this.$subTotal = this.$element.find("#stotal"); //displays the subtotal
            this.$shoppingCartActions = this.$element.find("#shopping-cart-actions");//cart action buttons 
        
            this.currency = "&pound;"; //HTML entity of the currency to be displayed in layout
            this.currencyString = "£"; //pound sign as string
            //regex for form validation
            this.requiredFields = {
                expression: {
                    value: /^([\w-\.]+)@((?:[\w]+\.)+)([a-z]){2,4}$/
                },
                
                str: {
                    value: ""
                }
            };
            //call the public methods
            this.createCart();
            this.AddToCartForm();
            this.displayCart();
            this.deleteProduct();
        },
        //creates the cart in session storage
        createCart: function() {
            if (this.storage.getItem(this.cartName) === null) {

                var cart = {};
                cart.items = [];

                this.storage.setItem(this.cartName, this._toJSONString(cart));
                this.storage.setItem(this.total, "0");
            }
        },
        //delete products from the shopping cart using the 'x'
        deleteProduct: function() {
            var self = this;
            if (self.$formCart.length) {
                var cart = this._toJSONObject(this.storage.getItem(this.cartName));
                var items = cart.items;

                $(document).on("click", ".pdelete a", function(e) {
                    e.preventDefault();
                    var productName = $(this).data("product");
                    var newItems = [];
                    for (var i = 0; i < items.length; ++i) {
                        var item = items[i];
                        var product = item.product;
                        if (product == productName) {
                            items.splice(i, 1);
                        }
                    }
                    newItems = items;
                    var updatedCart = {};
                    updatedCart.items = newItems;

                    var updatedTotal = 0;
                    var totalQty = 0;
                    if (newItems.length === 0) {
                        updatedTotal = 0;
                        totalQty = 0;
                    } else {
                        for (var j = 0; j < newItems.length; ++j) {
                            var prod = newItems[j];
                            var sub = prod.price * prod.qty;
                            updatedTotal += sub;
                            totalQty += prod.qty;
                        }
                    }
                    self.storage.setItem(self.total, self._convertNumber(updatedTotal));

                    self.storage.setItem(self.cartName, self._toJSONString(updatedCart));
                    $(this).parents("tr").remove();
                    self.$subTotal[0].innerHTML = self.currency + " " + self.storage.getItem(self.total);
                });
            }
        },
        //displays the shopping cart data as a more items are added to the cart
		displayCart: function() {
			if( this.$formCart.length ) {
				var cart = this._toJSONObject( this.storage.getItem( this.cartName ) );
				var items = cart.items;
				var $tableCart = this.$formCart.find( ".shopping-cart" );
				var $tableCartBody = $tableCart.find( "tbody" );

				if( items.length === 0 ) {
					$tableCartBody.html( "" );	
				} else {
				
				
					for( var i = 0; i < items.length; ++i ) {
						var item = items[i];
						var product = item.product;
						var price = this.currency + " " + item.price;
						var qty = item.qty;
						var html = "<tr><td class='pname'>" + product + "</td>" + "<td class='pqty'><input type='text' value='" + qty + "' class='qty'/></td>";
					    	html += "<td class='pprice'>" + price + "</td><td class='pdelete'><a href='' data-product='" + product + "'>&times;</a></td></tr>";
					
						$tableCartBody.html( $tableCartBody.html() + html );
					}

				}

				if( items.length === 0 ) {
					this.$subTotal[0].innerHTML = this.currency + " " + 0.00;
				} else {	
				
					var total = this.storage.getItem( this.total );
					this.$subTotal[0].innerHTML = this.currency + " " + total;
				}
			}
		},     
        //adds items to the shopping cart
        AddToCartForm: function() {
            var self = this;
            self.$formAddToCart.each(function() {
                var $form = $(this);
                var $product = $form.parent();
                var price = self._convertString($product.data("price"));
                var name = $product.data("name");

                $form.on("submit", function() {
                    var qty = self._convertString($form.find(".qty").val());
                    var subTotal = qty * price;
                    var total = self._convertString(self.storage.getItem(self.total));
                    var sTotal = total + subTotal;
                    self.storage.setItem(self.total, sTotal);
                    self._addToCart({
                        product: name,
                        price: price,
                        qty: qty
                    });
                });
            });
        },
        
        //invoke private methods
        
        
        //foramat a number by decimals
        _formatNumber: function(num, places) {
            var n = num.toFixed(places);
            return n;
        },
        //gets a number from a string
        _extractPrice: function(element) {
            var self = this;
            var text = element.text();
            var price = text.replace(self.currencyString, "").replace(" ", "");
            return price;
        },
        //converts a number string into a number
        _convertString: function(numStr) {
            var num;
            if (/^[-+]?[0-9]+\.[0-9]+$/.test(numStr)) {
                num = parseFloat(numStr);
            } else if (/^\d+$/.test(numStr)) {
                num = parseInt(numStr, 10);
            } else {
                num = Number(numStr);
            }

            if (!isNaN(num)) {
                return num;
            } else {
                console.warn(numStr + " cannot be converted into a number");
                return false;
            }
        },
        //converts a number into a string
        _convertNumber: function(n) {
            var str = n.toString();
            return str;
        },
        //converts a json string to a javascript object
        _toJSONObject: function(str) {
            var obj = JSON.parse(str);
            return obj;
        },
        //converts a javascript object to a json string
        _toJSONString: function(obj) {
            var str = JSON.stringify(obj);
            return str;
        },
        //adds an object to the cart as a json string
        _addToCart: function(values) {
            var cart = this.storage.getItem(this.cartName);

            var cartObject = this._toJSONObject(cart);
            var cartCopy = cartObject;
            var items = cartCopy.items;
            items.push(values);

            this.storage.setItem(this.cartName, this._toJSONString(cartCopy));
        },    
    };
    $(function() {
        var car = new $.Car("#site");// instance of an object
    });
})(jQuery);