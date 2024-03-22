/* eslint-disable react/prop-types */
import { Table, Button } from 'reactstrap'

function TablaContacto({ data, setEditar, mostrarModal, setMostrarModal, eliminarContacto }) {

    const enviarDatos = (contacto) => {
        setEditar(contacto)
        setMostrarModal(!mostrarModal)
    }

    return (
        <Table striped responsive>
            <thread>
                <tr>
                    <th>Nombre</th>
                    <th>Correo</th>
                    <th>Telefono</th>
                    <th></th>
                </tr>
            </thread>
            <tbody>
                {
                    // eslint-disable-next-line react/prop-types
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="4">Sin registros</td>
                        </tr>
                    ) : (
                            // eslint-disable-next-line react/prop-types
                            data.map(item => (
                                <tr key={item.idContacto}>
                                    <td>(item.nombre)</td>
                                    <td>(item.correo)</td>
                                    <td>(item.telefono)</td>
                                    <td>
                                        <Button color="primary" size="sm" className="me-2" onClick={() => enviarDatos(item)}>Editar</Button>
                                        <Button color="danger" size="sm" onClick={() => eliminarContacto(item.idContacto)}>Eliminar</Button>
                                    </td>
                                </tr>
                            ))
                    )
                }
            </tbody>
        </Table>
    );
}

export default TablaContacto