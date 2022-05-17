SELECT  
    DATE_FORMAT(A1.CriadoEm, '%d/%m/%Y') AS DATA_EMISSAO,
    DATE_FORMAT(A1.DataPrevisao, '%d/%m/%Y') AS DATA_PREVISAO,
    DATE_FORMAT(A1.DataVencimento, '%d/%m/%Y')  as DATA_VENCIMENTO,
    A2.Nome AS ENTIDADE,
    A3.Nome AS CATEGORIA,
    A5.Nome AS TAG,
    A1.Descricao AS DESCRICAO,
    A1.Observacao AS OBSERVACAO,
    A1.Valor AS VALOR,
    A1.Efetivado AS EFETIVADO,
    DATE_FORMAT(A1.DataPagamento, '%d/%m/%Y') AS DATA_PAGAMENTO
FROM despesa A1
JOIN entidade A2 ON A1.EntidadeId = A2.Id
JOIN categoria A3 ON A1.CategoriaId = A3.Id
INNER JOIN despesatag A4 ON A1.Id = A4.DespesaId
JOIN tag A5 ON A4.TagId = A5.Id