## 2.a 

* ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
La relacion entre Pedido y Cliente es por composicion.
La relacion entre Pedido y Cadete es por agregacion.
La relacion entre Cadete y Cadeteria es por agregacion.

* ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

La cadeteria deberia tener: agregarCadete, reasignarPedido, generarInforme, cambiarEstado.
La clase cadete deberia tener: agregarPedido, cancelarPedido, entregarPedido, cambiarEstado.

* Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados

Los atributos del cliente deberian ser privados.
En Pedidos, el Cliente deberia ser privado.
En Cadete el ListadoPedidos deberia ser privado
En Cadeteria el ListadoCadete deberia ser privado.

* ¿Cómo diseñaría los constructores de cada una de las clases?

El constructor de Pedido lo diseñaria de forma que reciba como parametro al cliente

* ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?

El cadete podria ser un atributo del pedido y que la cadeteria tenga el listado de pedidos.