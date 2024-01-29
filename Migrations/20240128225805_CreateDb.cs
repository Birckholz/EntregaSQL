using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntregaSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    idConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.idConta);
                });

            migrationBuilder.CreateTable(
                name: "filiaisHoteis",
                columns: table => new
                {
                    idFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    numQuartosSolteiro = table.Column<int>(type: "int", nullable: false),
                    numQuartosCasal = table.Column<int>(type: "int", nullable: false),
                    numQuartosFamilia = table.Column<int>(type: "int", nullable: false),
                    numQuartosPresidencial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filiaisHoteis", x => x.idFilial);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    idFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.idFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    idServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeServ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.idServico);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    idPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idConta = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.idPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Contas_idConta",
                        column: x => x.idConta,
                        principalTable: "Contas",
                        principalColumn: "idConta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    idEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rua = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    idFilial = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.idEndereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Enderecos_filiaisHoteis_idFilial",
                        column: x => x.idFilial,
                        principalTable: "filiaisHoteis",
                        principalColumn: "idFilial");
                });

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    idQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFilial = table.Column<int>(type: "int", nullable: false),
                    fkfilialHotelidFilial = table.Column<int>(type: "int", nullable: true),
                    acomadaEsp = table.Column<bool>(type: "bit", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    valor = table.Column<float>(type: "real", nullable: false),
                    maxCap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.idQuarto);
                    table.ForeignKey(
                        name: "FK_Quartos_filiaisHoteis_fkfilialHotelidFilial",
                        column: x => x.fkfilialHotelidFilial,
                        principalTable: "filiaisHoteis",
                        principalColumn: "idFilial");
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    idTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    clienteTidCliente = table.Column<int>(type: "int", nullable: true),
                    idFilial = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.idTelefone);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_clienteTidCliente",
                        column: x => x.clienteTidCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Telefones_filiaisHoteis_idFilial",
                        column: x => x.idFilial,
                        principalTable: "filiaisHoteis",
                        principalColumn: "idFilial");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idFuncionario = table.Column<int>(type: "int", nullable: false),
                    statusPedido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.idReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Funcionarios_idFuncionario",
                        column: x => x.idFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "idFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicosConta",
                columns: table => new
                {
                    idServico = table.Column<int>(type: "int", nullable: false),
                    idConta = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicosConta", x => new { x.idServico, x.idConta });
                    table.ForeignKey(
                        name: "FK_servicosConta_Contas_idConta",
                        column: x => x.idConta,
                        principalTable: "Contas",
                        principalColumn: "idConta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicosConta_Servicos_idServico",
                        column: x => x.idServico,
                        principalTable: "Servicos",
                        principalColumn: "idServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contaHospedagems",
                columns: table => new
                {
                    idConta = table.Column<int>(type: "int", nullable: false),
                    idReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contaHospedagems", x => new { x.idConta, x.idReserva });
                    table.ForeignKey(
                        name: "FK_contaHospedagems_Contas_idConta",
                        column: x => x.idConta,
                        principalTable: "Contas",
                        principalColumn: "idConta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contaHospedagems_Reservas_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reservas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaQuartos",
                columns: table => new
                {
                    idReserva = table.Column<int>(type: "int", nullable: false),
                    idQuarto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaQuartos", x => new { x.idReserva, x.idQuarto });
                    table.ForeignKey(
                        name: "FK_ReservaQuartos_Quartos_idQuarto",
                        column: x => x.idQuarto,
                        principalTable: "Quartos",
                        principalColumn: "idQuarto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaQuartos_Reservas_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reservas",
                        principalColumn: "idReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contaHospedagems_idReserva",
                table: "contaHospedagems",
                column: "idReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_idCliente",
                table: "Enderecos",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_idFilial",
                table: "Enderecos",
                column: "idFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_idConta",
                table: "Pagamentos",
                column: "idConta");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_fkfilialHotelidFilial",
                table: "Quartos",
                column: "fkfilialHotelidFilial");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaQuartos_idQuarto",
                table: "ReservaQuartos",
                column: "idQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_idCliente",
                table: "Reservas",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_idFuncionario",
                table: "Reservas",
                column: "idFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_servicosConta_idConta",
                table: "servicosConta",
                column: "idConta");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_clienteTidCliente",
                table: "Telefones",
                column: "clienteTidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_idFilial",
                table: "Telefones",
                column: "idFilial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contaHospedagems");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "ReservaQuartos");

            migrationBuilder.DropTable(
                name: "servicosConta");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "filiaisHoteis");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
