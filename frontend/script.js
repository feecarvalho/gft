const previousOrderList = document.getElementById("previous-orders-list")

const handleOrder = async () => {
  const value = document.getElementById("order-input").value
  if (!value) return
  const order = { "input": value }
  await requestOrder(order)
}

const requestOrder = async (order) => {
  try {
    const url = "https://localhost:7197/OrderMeal"
    const options = {
      method: "POST",
      headers: {'content-type': 'application/json;charset=UTF-8'},
      body: JSON.stringify(order)
    }
    const response = await fetch(url, options)
    const result = await response.json()
    const errorSpan = document.getElementById("invalid-order-error")
    if (result.error) {
      errorSpan.innerHTML = result.error
    }
    const listItem = document.createElement("li")
    listItem.innerHTML = result.output
    previousOrderList.appendChild(listItem)
    console.log(previousOrderList)
  } catch(error) {
  }
}