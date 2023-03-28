const apolloClient = new Apollo.lib.ApolloClient({
    networkInterface: Apollo.lib.createNetworkInterface({
        uri: 'https://localhost:7154/graphql',
        transportBatching: true,
    }),
    connectToDevTools: true,
});


function renderDetail(registryNumber) {
    const query = Apollo.gql`
    query detailsForCars($registryNumber: String!) 
    {
        car(registryNumber: $registryNumber) {
            registryNumber
            brand 
            model 
            yearModel 
            color 
        }  
    }`
        ;

    apolloClient
        .query({
            query: query,
            variables: { registryNumber: registryNumber }
        }).then(result => {
            const div = document.getElementById("details");
            result.data.Car.forEach(car => {
                div.innerHTML +=
                    `<div class="row">
                        <div class="col-12"><h5>${car.registryNumber}</h5></div>
                    </div>
                    <div class="row mb-2">
                        <div class="col-12">${car.brand}</div>
                    </div>
                      <div class="row mb-2">
                        <div class="col-12">${car.model}</div>
                    </div>
                      <div class="row mb-2">
                        <div class="col-12">${car.yearModel}</div>
                    </div>
                     <div class="row mb-2">
                        <div class="col-12">${car.color}</div>
                    </div>`;
            })
        })
};