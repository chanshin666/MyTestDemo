using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class FCreateOrgId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FUseOrgId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FMaterialGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FCategoryID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FTaxType
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FTaxRateId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FBaseUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FWEIGHTUNITID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FVOLUMEUNITID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string FBARCODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FErpClsID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCONFIGTYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FCategoryID FCategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FTaxType FTaxType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FTaxRateId FTaxRateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FBaseUnitId FBaseUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsPurchase { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsInventory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsSubContract { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsSale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsProduce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAsset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FGROSSWEIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FNETWEIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FWEIGHTUNITID FWEIGHTUNITID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FLENGTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FWIDTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FHEIGHT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVOLUME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FVOLUMEUNITID FVOLUMEUNITID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSuite { get; set; }
    }

    public class FStoreUnitID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FAuxUnitID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FStockId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FStockPlaceId
    {
    }

    public class FBatchRuleID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FCurrencyId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FSNCodeRule
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FSNUnit
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity1
    {
        /// <summary>
        /// 
        /// </summary>
        public FStoreUnitID FStoreUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FAuxUnitID FAuxUnitID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FUnitConvertDir { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FStockId FStockId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FStockPlaceId FStockPlaceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsLockStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsCycleCounting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCountCycle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCountDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsMustCounting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsBatchManage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FBatchRuleID FBatchRuleID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsKFPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsExpParToFlot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FExpUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FExpPeriod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOnlineLife { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FRefCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FCurrencyId FCurrencyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsEnableMinStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsEnableMaxStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsEnableSafeStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsEnableReOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMinStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSafeStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FReOrderGood { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEconReOrderQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMaxStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsSNManage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsSNPRDTracy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FSNCodeRule FSNCodeRule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FSNUnit FSNUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSNManageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSNGenerateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FBoxStandardQty { get; set; }
    }

    public class FSaleUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FSalePriceUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FTaxCategoryCodeId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity2
    {
        /// <summary>
        /// 
        /// </summary>
        public FSaleUnitId FSaleUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FSalePriceUnitId FSalePriceUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMinQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMaxQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOutStockLmtH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOutStockLmtL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FAgentSalReduceRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsATPCheck { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsReturnPart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsInvoice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsReturn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FAllowPublish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FISAFTERSALE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FISPRODUCTFILES { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FISWARRANTED { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FWARRANTY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FWARRANTYUNITID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOutLmtUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FTaxCategoryCodeId FTaxCategoryCodeId { get; set; }
    }

    public class FPurchaseUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPurchasePriceUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPurchaseOrgId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPurchaseGroupId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPurchaserId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FDefaultVendor
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FChargeID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FDefBarCodeRuleId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity3
    {
        /// <summary>
        /// 
        /// </summary>
        public string FBaseMinSplitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPurchaseUnitId FPurchaseUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPurchasePriceUnitId FPurchasePriceUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPurchaseOrgId FPurchaseOrgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPurchaseGroupId FPurchaseGroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPurchaserId FPurchaserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FDefaultVendor FDefaultVendor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FChargeID FChargeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsQuota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FQuotaType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMinSplitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsVmiBusiness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEnableSL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsPR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsReturnMaterial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsSourceControl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FReceiveMaxScale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FReceiveMinScale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FReceiveAdvanceDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FReceiveDelayDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FAgentPurPlusRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FDefBarCodeRuleId FDefBarCodeRuleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPrintCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMinPackCount { get; set; }
    }

    public class FMfgPolicyId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPlanWorkshop
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPlanGroupId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPlanerID
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FSupplySourceId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FTimeFactorId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FQtyFactorId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity4
    {
        /// <summary>
        /// 
        /// </summary>
        public string FPlanMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FBaseVarLeadTimeLotSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanningStrategy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FMfgPolicyId FMfgPolicyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderPolicy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPlanWorkshop FPlanWorkshop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFixLeadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFixLeadTimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVarLeadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVarLeadTimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckLeadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckLeadTimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderIntervalTimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOrderIntervalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMaxPOQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMinPOQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIncreaseQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEOQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FVarLeadTimeLotSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanIntervalsDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanBatchSplitQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FRequestTimeZone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanTimeZone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPlanGroupId FPlanGroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPlanerID FPlanerID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCanLeadDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsMrpComReq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FLeadExtendDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FReserveType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanSafeStockQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FAllowPartAhead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCanDelayDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FDelayExtendDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FAllowPartDelay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanOffsetTimeType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FPlanOffsetTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FSupplySourceId FSupplySourceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FTimeFactorId FTimeFactorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FQtyFactorId FQtyFactorId { get; set; }
    }

    public class FWorkShopId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FProduceUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FProduceBillType
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FOrgTrustBillType
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FBOMUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPickStockId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FPickBinId
    {
    }

    public class FDefaultRouting
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FMinIssueUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FMdlId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FMdlMaterialId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity5
    {
        /// <summary>
        /// 
        /// </summary>
        public FWorkShopId FWorkShopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FProduceUnitId FProduceUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFinishReceiptOverRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FFinishReceiptShortRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FProduceBillType FProduceBillType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FOrgTrustBillType FOrgTrustBillType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsProductLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FBOMUnitId FBOMUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FConsumVolatility { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsMainPrd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsCoby { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsECN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIssueType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FBKFLTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPickStockId FPickStockId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FPickBinId FPickBinId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOverControlMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMinIssueQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FISMinIssueQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsKitting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsCompleteSet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FDefaultRouting FDefaultRouting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FStdLaborPrePareTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FStdLaborProcessTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FStdMachinePrepareTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FStdMachineProcessTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FMinIssueUnitId FMinIssueUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FMdlId FMdlId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FMdlMaterialId FMdlMaterialId { get; set; }
    }

    public class FSubconUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FSubconPriceUnitId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FSubBillType
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity7
    {
        /// <summary>
        /// 
        /// </summary>
        public FSubconUnitId FSubconUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FSubconPriceUnitId FSubconPriceUnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FSubBillType FSubBillType { get; set; }
    }

    public class FIncSampSchemeId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FIncQcSchemeId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FInspectGroupId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FInspectorId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class SubHeadEntity6
    {
        /// <summary>
        /// 
        /// </summary>
        public string FCheckIncoming { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckProduct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckStock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckReturn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckDelivery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEnableCyclistQCSTK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FStockCycle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEnableCyclistQCSTKEW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FEWLeadDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FIncSampSchemeId FIncSampSchemeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FIncQcSchemeId FIncQcSchemeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FInspectGroupId FInspectGroupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FInspectorId FInspectorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FCheckEntrusted { get; set; }
    }

    public class FAuxPropertyId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNUMBER { get; set; }
    }

    public class FEntityAuxPtyItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string FEntryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FAuxPropertyId FAuxPropertyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsEnable1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsComControl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAffectPrice1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAffectPlan1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAffectCost1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsMustInput { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FValueType { get; set; }
    }

    public class FInvPtyId
    {
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
    }

    public class FEntityInvPtyItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string FEntryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FInvPtyId FInvPtyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsEnable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAffectPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAffectPlan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsAffectCost { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string FMATERIALID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FCreateOrgId FCreateOrgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FUseOrgId FUseOrgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FSpecification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FMnemonicCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FOldNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public FMaterialGroup FMaterialGroup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FImgStorageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FIsSalseByNet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity SubHeadEntity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity1 SubHeadEntity1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity2 SubHeadEntity2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity3 SubHeadEntity3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity4 SubHeadEntity4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity5 SubHeadEntity5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity7 SubHeadEntity7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SubHeadEntity6 SubHeadEntity6 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FEntityAuxPtyItem> FEntityAuxPty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FEntityInvPtyItem> FEntityInvPty { get; set; }
    }
}